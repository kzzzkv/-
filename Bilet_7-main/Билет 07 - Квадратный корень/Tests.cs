using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket07;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.SquareRoot(81) == 9);
        Assert(TicketTasks.FilterStringsByLength(new[] { "cat", "window", "code" }, 4).SequenceEqual(new[] { "window", "code" }));
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
