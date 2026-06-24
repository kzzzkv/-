using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket08;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.AbsoluteValue(-12.5) == 12.5);
        Assert(TicketTasks.TransformStrings(new[] { " hello ", "world" }).SequenceEqual(new[] { "HELLO", "WORLD" }));
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
