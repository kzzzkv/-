using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket24;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.HasLength(new[] { "a", "b", "c" }, 3));
        Assert(TicketTasks.ChainOperations(new[] { -2, 4, 1, 2, 3 }).SequenceEqual(new[] { 4, 16 }));
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
