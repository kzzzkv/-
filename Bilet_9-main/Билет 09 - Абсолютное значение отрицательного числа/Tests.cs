using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket09;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.AbsoluteNegativeNumber(-15) == 15);
        Assert(TicketTasks.FindStringsByPrefix(new[] { "apple", "apricot", "pear" }, "ap").SequenceEqual(new[] { "apple", "apricot" }));
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
