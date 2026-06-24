using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket03;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.Multiply(6, 7) == 42);
        Assert(TicketTasks.SortAscending(new[] { 5, 1, 3 }).SequenceEqual(new[] { 1, 3, 5 }));
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
