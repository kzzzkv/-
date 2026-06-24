using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket06;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.Power(2, 4) == 16);
        Assert(TicketTasks.SkipFirstN(new[] { 1, 2, 3, 4 }, 2).SequenceEqual(new[] { 3, 4 }));
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
