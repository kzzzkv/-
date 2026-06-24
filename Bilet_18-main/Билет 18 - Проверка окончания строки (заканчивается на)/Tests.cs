using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket18;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.EndsWithText("document.pdf", ".pdf"));
        Assert(TicketTasks.HasAnyPositive(new[] { -5, 0, 2 }));
    }

    private static void Assert(bool condition)
    {
        Debug.Assert(condition);
        if (!condition)
        {
            throw new InvalidOperationException("Assert failed in ticket tests.");
        }
    }
}
