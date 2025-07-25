import {
  test,
  expect,
  type Frame,
  type Page,
  type ElementHandle,
} from '@playwright/test';

// Shared setup function for number input tests
async function setupNumberInputPage(page: Page): Promise<Frame | null> {
  await page.goto('/');
  await page.waitForLoadState('networkidle');

  // Navigate to Number Inputs app
  const searchInput = page.getByTestId('sidebar-search');
  await expect(searchInput).toBeVisible();
  await searchInput.click();
  await searchInput.fill('number input');
  await searchInput.press('Enter');

  const firstResult = page
    .locator('[data-sidebar="menu-item"], [data-sidebar="menu-sub-item"]')
    .filter({ hasText: /Number Input/i })
    .first();

  await expect(firstResult).toBeVisible();
  await firstResult.click();
  await page.waitForLoadState('networkidle');

  // More robust iframe detection with retry logic
  let appFrameElement: ElementHandle<SVGElement | HTMLElement> | null = null;
  let contentFrame: Frame | null = null;
  let retries = 0;
  const maxRetries = 10;

  while (!contentFrame && retries < maxRetries) {
    try {
      appFrameElement = await page.waitForSelector(
        'iframe[src*="number-input"]',
        { timeout: 2000 }
      );

      await page.waitForTimeout(1000);

      contentFrame = await appFrameElement.contentFrame();

      if (!contentFrame) {
        await page.waitForTimeout(500);
        contentFrame = await appFrameElement.contentFrame();
      }
    } catch (error) {
      retries++;
      if (retries >= maxRetries) {
        throw new Error(
          `Failed to find iframe or content frame after ${maxRetries} retries. Last error: ${error}`
        );
      }
      await page.waitForTimeout(500);
    }
  }

  if (!appFrameElement) {
    throw new Error('Iframe element not found');
  }

  if (!contentFrame) {
    throw new Error('Iframe content frame is null after all retries');
  }

  await contentFrame.waitForLoadState('domcontentloaded');

  return contentFrame;
}

test.describe('Number Inputs - Variants Section', () => {
  let appFrame: Frame | null;

  test.beforeEach(async ({ page }) => {
    appFrame = await setupNumberInputPage(page);
  });

  test.skip('should display all variants in the grid', async () => {
    expect(appFrame).not.toBeNull();

    // Assert that the frame exists before using it
    if (!appFrame) {
      throw new Error('App frame not found');
    }

    // Check that the variants section exists
    await expect(
      appFrame.locator('h2').filter({ hasText: 'Variants' })
    ).toBeVisible();

    await expect(
      appFrame.getByTestId('number-input-nullable-main')
    ).toBeVisible();
    await expect(appFrame.getByTestId('number-input-int-main')).toBeVisible();
    await expect(
      appFrame.getByTestId('number-input-int-disabled-main')
    ).toBeVisible();
    await expect(
      appFrame.getByTestId('number-input-int-invalid-main')
    ).toBeVisible();

    await expect(
      appFrame.getByTestId('number-input-nullable-slider-main')
    ).toBeVisible();
    await expect(
      appFrame.getByTestId('number-input-int-slider-main')
    ).toBeVisible();
    await expect(
      appFrame.getByTestId('number-input-int-disabled-slider-main')
    ).toBeVisible();
    await expect(
      appFrame.getByTestId('number-input-int-invalid-slider-main')
    ).toBeVisible();
  });
});
