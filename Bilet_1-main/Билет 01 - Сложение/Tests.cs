using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket01;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.Add(2, 3) == 5);
        Assert(TicketTasks.FilterEvenNumbers(new[] { 1, 2, 3, 4, 6 }).SequenceEqual(new[] { 2, 4, 6 }));
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
