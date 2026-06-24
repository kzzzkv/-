using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket12;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.ToUpperCase("hello") == "HELLO");
        Assert(TicketTasks.FindMax(new[] { 3, 9, 1 }) == 9);
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
