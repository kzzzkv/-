using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket25;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.IsEmptyString("   "));
        Assert(TicketTasks.FindUniqueElements(new[] { 1, 2, 2, 3, 4, 4 }).SequenceEqual(new[] { 1, 3 }));
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
