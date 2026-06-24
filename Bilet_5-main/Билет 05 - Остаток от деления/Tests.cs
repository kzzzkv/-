using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket05;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.Remainder(17, 5) == 2);
        Assert(TicketTasks.TakeFirstN(new[] { 1, 2, 3, 4 }, 2).SequenceEqual(new[] { 1, 2 }));
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
