using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket17;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.StartsWithText("Programming", "pro"));
        Assert(TicketTasks.AreAllPositive(new[] { 1, 2, 3 }));
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
