using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket13;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.ToLowerCase("HELLO") == "hello");
        Assert(TicketTasks.FindMin(new[] { 3, 9, 1 }) == 1);
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
