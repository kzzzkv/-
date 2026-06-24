using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket19;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.ContainsSubstring("Visual Studio", "studio"));
        Dictionary<string, int[]> groups = TicketTasks.GroupByEvenOdd(new[] { 1, 2, 3, 4 });
        Assert(groups["Odd"].SequenceEqual(new[] { 1, 3 }));
        Assert(groups["Even"].SequenceEqual(new[] { 2, 4 }));
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
