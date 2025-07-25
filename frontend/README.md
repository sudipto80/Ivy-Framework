# Frontend

**Node.js Version Requirement**: This project requires Node.js version 22.12.0 or greater.

## Development

```bash
npm run dev
npm run build
```

## Developer Logging

The frontend includes a comprehensive logging system for debugging and development purposes. Detailed logging can be controlled via browser console commands.

### Console Commands

Open the browser console (F12 → Console tab) and use these commands:

```javascript
// Check current developer options
getDeveloperOptions();
// Returns: { showDetailedLogging: false }

// Toggle detailed logging on/off
toggleDeveloperLogging();
// Returns: true (if enabled) or false (if disabled)
// Also logs: "Developer logging enabled" or "Developer logging disabled"
```

### What Gets Logged

When detailed logging is enabled, you'll see debug messages for:

- **Select Input Interactions**: Value changes, conversions, clear operations
- **SignalR Communication**: Message processing, updates, events
- **Widget Tree Operations**: XML conversion, patches, updates
- **Authentication**: JWT operations, theme changes
- **Error Handling**: Connection issues, parsing errors

### Log Levels

- **Debug**: Detailed information (controlled by `showDetailedLogging`)
- **Info**: General information (always visible)
- **Warn**: Warning messages (always visible)
- **Error**: Error messages (always visible)

### Persistence

Developer options are stored in localStorage and persist across:

- Page refreshes
- Browser sessions
- Browser restarts

### Example Usage

```javascript
// Enable detailed logging
toggleDeveloperLogging();
// Interact with select inputs, forms, etc.
// See detailed debug messages in console

// Disable detailed logging
toggleDeveloperLogging();
// Only info, warn, and error messages will appear
```

## Code Quality

This project uses ESLint and Prettier for code quality and formatting, with automatic pre-commit hooks.

### Code Formatting

Format all files with Prettier:

```bash
npm run format
```

Check if files are properly formatted:

```bash
npm run format:check
```

### Linting

Check for linting issues:

```bash
npm run lint
```

Automatically fix linting issues:

```bash
npm run lint:fix
```

### Pre-commit Hooks

The project uses Git pre-commit hooks to automatically:

- Run ESLint with auto-fix on staged files
- Format staged files with Prettier
- Block commits if any issues remain

The pre-commit hook is configured at the repository root and automatically detects the frontend directory.

### Configuration Files

- `.prettierrc` - Prettier configuration
- `.prettierignore` - Files to exclude from formatting
- `eslint.config.js` - ESLint configuration with Prettier integration
- `package.json` - Contains lint-staged configuration and scripts

## Testing

This project uses Playwright for end-to-end testing.

### Prerequisites

Make sure you're in the frontend directory:

```bash
cd frontend
```

### Install Dependencies

```bash
npm ci
```

### Install Playwright Browsers

```bash
npx playwright install --with-deps
```

### Running Tests

Run all tests:

```bash
npx playwright test
```

Run tests in a specific browser:

```bash
npx playwright test --project=chromium
npx playwright test --project=firefox
npx playwright test --project=webkit
```

Run tests in headed mode (to see the browser):

```bash
npx playwright test --headed
```

Run tests in debug mode:

```bash
npx playwright test --debug
```

Run a specific test file:

```bash
npx playwright test example.spec.ts
```

### Test Reports

View the HTML test report:

```bash
npx playwright show-report
```

### Test Files

- `e2e/` - End-to-end test files

### CI/CD

Tests are automatically run in GitHub Actions on push to main/master branches and pull requests. The CI pipeline includes:

1. Code formatting checks (`npm run format:check`)
2. Linting checks (`npm run lint`)
3. Playwright end-to-end tests

## Available Scripts

| Script                 | Description                           |
| ---------------------- | ------------------------------------- |
| `npm run dev`          | Start development server              |
| `npm run build`        | Build for production                  |
| `npm run preview`      | Preview production build              |
| `npm run lint`         | Check for linting issues              |
| `npm run lint:fix`     | Fix linting issues automatically      |
| `npm run format`       | Format all files with Prettier        |
| `npm run format:check` | Check if files are properly formatted |

## Husky

If you're having issues with husky on pre commits on Windows you can temporary disable:

```bash
git config core.hooksPath NUL
```

Reset:

```bash
git config --unset core.hooksPath
```
