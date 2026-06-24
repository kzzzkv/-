using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ticket02;

public class MainForm : Form
{
    private readonly TextBox firstInputA = new();
    private readonly TextBox firstInputB = new();
    private readonly TextBox secondValues = new();
    private readonly TextBox secondParameter = new();
    private readonly Label firstResult = new();
    private readonly Label secondResult = new();

    public MainForm()
    {
        Text = "Билет 02 - Вычитание";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(760, 520);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(18),
            ColumnCount = 1,
            RowCount = 3,
        };
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        Controls.Add(layout);

        var header = new Label
        {
            Text = "Билет 02 - Вычитание",
            AutoSize = true,
            Font = new Font(Font.FontFamily, 15, FontStyle.Bold),
            Margin = new Padding(0, 0, 0, 12),
        };
        layout.Controls.Add(header, 0, 0);

        layout.Controls.Add(CreateFirstTaskPanel(), 0, 1);
        layout.Controls.Add(CreateSecondTaskPanel(), 0, 2);
    }

    private Control CreateFirstTaskPanel()
    {
        var group = new GroupBox
        {
            Text = "Task 1: " + TicketTasks.FirstTaskTitle,
            Dock = DockStyle.Fill,
            Padding = new Padding(12),
        };

        var grid = CreateGrid();
        group.Controls.Add(grid);

        firstInputA.Text = "10";
        firstInputB.Text = "4";
        AddRow(grid, "Value A / text", firstInputA);
        AddRow(grid, "Value B / option", firstInputB);

        var button = new Button { Text = "Run task 1", AutoSize = true };
        button.Click += (_, _) => RunSafely(() => firstResult.Text = TicketTasks.RunFirstDemo(firstInputA.Text, firstInputB.Text));
        AddRow(grid, string.Empty, button);

        firstResult.AutoSize = true;
        firstResult.MaximumSize = new Size(660, 0);
        AddRow(grid, "Result", firstResult);

        return group;
    }

    private Control CreateSecondTaskPanel()
    {
        var group = new GroupBox
        {
            Text = "Task 2: " + TicketTasks.SecondTaskTitle,
            Dock = DockStyle.Fill,
            Padding = new Padding(12),
        };

        var grid = CreateGrid();
        group.Controls.Add(grid);

        secondValues.Text = "2, 3, 4";
        secondParameter.Text = "";
        AddRow(grid, "Values", secondValues);
        AddRow(grid, "Parameter", secondParameter);

        var button = new Button { Text = "Run task 2", AutoSize = true };
        button.Click += (_, _) => RunSafely(() => secondResult.Text = TicketTasks.RunSecondDemo(secondValues.Text, secondParameter.Text));
        AddRow(grid, string.Empty, button);

        secondResult.AutoSize = true;
        secondResult.MaximumSize = new Size(660, 0);
        AddRow(grid, "Result", secondResult);

        return group;
    }

    private static TableLayoutPanel CreateGrid()
    {
        var grid = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 4,
        };
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        return grid;
    }

    private static void AddRow(TableLayoutPanel grid, string labelText, Control control)
    {
        int row = grid.RowCount++;
        grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        grid.Controls.Add(new Label { Text = labelText, AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(0, 6, 8, 0) }, 0, row);
        control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        control.Margin = new Padding(0, 3, 0, 3);
        grid.Controls.Add(control, 1, row);
    }

    private static void RunSafely(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
