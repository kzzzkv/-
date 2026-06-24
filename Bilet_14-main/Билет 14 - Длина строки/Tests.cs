using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket14;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.GetStringLength("student") == 7);
        Assert(TicketTasks.AverageValue(new[] { 2, 4, 6 }) == 4);
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
