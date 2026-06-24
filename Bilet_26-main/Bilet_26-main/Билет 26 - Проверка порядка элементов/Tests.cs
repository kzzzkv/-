using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket26;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.IsAscending(new[] { 1, 2, 2, 5 }));
        Assert(!TicketTasks.IsAscending(new[] { 1, 5, 2 }));
        Assert(TicketTasks.HasAnyGreaterThan(new[] { 1, 3, 8 }, 5));
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
