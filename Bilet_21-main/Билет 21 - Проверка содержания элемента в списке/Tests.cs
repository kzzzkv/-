using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket21;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.ListContainsElement(new[] { "red", "green" }, "green"));
        Assert(TicketTasks.UnionCollections(new[] { 1, 2 }, new[] { 2, 3 }).SequenceEqual(new[] { 1, 2, 3 }));
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
