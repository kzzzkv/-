using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket04;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.Divide(10, 2) == 5);
        Assert(TicketTasks.SortDescending(new[] { 5, 1, 3 }).SequenceEqual(new[] { 5, 3, 1 }));
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
