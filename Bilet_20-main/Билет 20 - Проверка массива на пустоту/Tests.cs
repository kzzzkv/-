using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket20;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.IsArrayEmpty(Array.Empty<int>()));
        Assert(TicketTasks.RemoveDuplicates(new[] { 1, 2, 2, 3, 1 }).SequenceEqual(new[] { 1, 2, 3 }));
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
