using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket22;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.ListDoesNotContainElement(new[] { "red", "green" }, "blue"));
        Assert(TicketTasks.IntersectCollections(new[] { 1, 2, 3 }, new[] { 2, 3, 4 }).SequenceEqual(new[] { 2, 3 }));
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
