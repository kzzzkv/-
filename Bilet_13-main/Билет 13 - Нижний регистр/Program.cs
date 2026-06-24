using System;
using System.Windows.Forms;

namespace Ticket13;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Tests.RunAll();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
