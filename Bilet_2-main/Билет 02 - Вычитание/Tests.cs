using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket02;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.Subtract(10, 4) == 6);
        Assert(TicketTasks.SquareNumbers(new[] { 2, 3, 4 }).SequenceEqual(new[] { 4, 9, 16 }));
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
