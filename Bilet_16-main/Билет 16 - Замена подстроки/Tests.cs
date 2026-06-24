using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket16;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.ReplaceSubstring("one two one", "one", "three") == "three two three");
        Assert(TicketTasks.ContainsElement(new[] { 1, 2, 3 }, 2));
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
