using Ivy.Core;
using Ivy.Shared;
using Squirrel;
using Squirrel.Cleansing;

namespace Ivy;

/// <summary>Table widget displaying structured data in tabular format with <see cref="TableRow"/> elements supporting pipe operator for easy row addition.</summary>
public record Table : WidgetBase<Table>
{
    // ✅ FIXED: Instance-level (not static), internal access for extensions
    internal Squirrel.Table _internalTable { get; init; } = new();
   

    /// <summary>Initializes Table with specified table rows.</summary>
    /// <param name="rows">TableRow elements defining table structure and content.</param>
    public Table(params TableRow[] rows) : base(rows.Cast<object>().ToArray())
    {
        // Initialize internal table
        _internalTable = new Squirrel.Table();

        if (rows.Length == 0) return;

        // Step 1: Extract column names from header row
        List<string> columnNames = new();
        List<Dictionary<string, string>> squirrelTableRows = new();

        foreach (var row in rows)
        {
            // Read header row for column names
            if (row.IsHeader)
            {
                foreach (var child in row.Children)
                {
                    var colName = child.ToString() ?? "Column";
                    columnNames.Add(colName);
                }
            }
            else // Data rows
            {
                // ✅ FIXED: Dictionary created ONCE per row
                Dictionary<string, string> squirrelRow = new();

                // ✅ FIXED: Loop just populates the dictionary
                for (int i = 0; i < columnNames.Count && i < row.Children.Count(); i++)
                {
                    var colValue = row.Children[i].ToString() ?? string.Empty;
                    squirrelRow.Add(columnNames[i], colValue);
                }

                // ✅ FIXED: Add to list OUTSIDE the inner loop
                squirrelTableRows.Add(squirrelRow);
            }
        }

        // Step 2: Initialize Squirrel table columns
        // ✅ FIXED: Must initialize columns before adding rows
        foreach (var colName in columnNames)
        {
            _internalTable.AddColumn(colName, new List<string>());
        }

        // Step 3: Add rows to Squirrel table
        foreach (var row in squirrelTableRows)
        {
            _internalTable.AddRow(row);
        }
    }

    /// <summary>Gets or sets the size of the table.</summary>
    [Prop] public Sizes Size { get; set; } = Sizes.Medium;

    /// <summary>Allows adding single TableRow using pipe operator for convenient table construction.</summary>
    public static Table operator |(Table table, TableRow child)
    {
        // Create new table with additional row
        var newRows = table.Children.Cast<TableRow>().Append(child).ToArray();
        return new Table(newRows) { Size = table.Size };
    }
}

/// <summary>Provides extension methods for configuring table widgets with fluent syntax.</summary>
public static class TableExtensions
{
    /// <summary>Sets the size of the table.</summary>
    public static Table Size(this Table widget, Sizes size) => widget with { Size = size };

    /// <summary>Sets the table size to large for prominent display.</summary>
    public static Table Large(this Table widget) => widget.Size(Sizes.Large);

    /// <summary>Sets the table size to small for compact display.</summary>
    public static Table Small(this Table widget) => widget.Size(Sizes.Small);

    /// <summary>Sets the table size to medium for medium display.</summary>
    public static Table Medium(this Table widget) => widget.Size(Sizes.Medium);

    // ========================================
    // SQUIRREL-POWERED EXTENSIONS
    // ========================================

    /// <summary>Sorts table by column using Squirrel</summary>
    public static Table SortBy(this Table table, string column, bool descending = false)
    {
        // ✅ FIXED: Access internal table through table instance
        var sorted = table._internalTable.SortBy(
            column,
            how: descending ? Squirrel.SortDirection.Descending : Squirrel.SortDirection.Ascending
        );

        // Convert sorted Squirrel table back to Ivy Table
        return ConvertSquirrelTableToIvyTable(sorted, table.Size);
    }


    /// <summary>
    /// Converts a Squirrel.Table to an Ivy.Table with proper row and cell structure
    /// </summary>
    /// <param name="squirrelTable">The Squirrel table to convert</param>
    /// <param name="size">The size to apply to the resulting Ivy table</param>
    /// <returns>An Ivy Table with header row and data rows</returns>
    private static Table ConvertSquirrelTableToIvyTable(Squirrel.Table squirrelTable, Sizes size)
    {
        var rows = new List<TableRow>();

        // Step 1: Create header row from Squirrel column names
        var headerCells = squirrelTable.ColumnHeaders
            .Select(columnName => new TableCell(columnName))
            .ToArray();

        var headerRow = new TableRow(headerCells) { IsHeader = true };
        rows.Add(headerRow);

        // Step 2: Create data rows from Squirrel table rows
        foreach (var squirrelRow in squirrelTable.Rows)
        {
            var dataCells = squirrelTable.ColumnHeaders
                .Select(columnName =>
                {
                    // Get value from Squirrel row
                    var value = squirrelRow.ContainsKey(columnName)
                        ? squirrelRow[columnName]
                        : string.Empty;

                    return new TableCell(value);
                })
                .ToArray();

            rows.Add(new TableRow(dataCells));
        }

        // Step 3: Create and return the Ivy Table
        return new Table(rows.ToArray()) { Size = size };
    }

}