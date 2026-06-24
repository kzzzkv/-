using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Ticket10;

public static class Tests
{
    public static void RunAll()
    {
        Assert(TicketTasks.RoundNumber(3.14159, 2) == 3.14);
        Assert(TicketTasks.JoinStrings(new[] { "red", "green", "blue" }, "-") == "red-green-blue");
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
