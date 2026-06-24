using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket23;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.IsValidDate("2026-06-20"));
        Assert(TicketTasks.DifferenceCollections(new[] { 1, 2, 3, 4 }, new[] { 2, 4 }).SequenceEqual(new[] { 1, 3 }));
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
