using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket05;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Остаток от деления";
    public const string SecondTaskTitle = "Выбор первых N элементов";

    public static int Remainder(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Second number must not be zero.");
        }

        return a % b;
    }

    public static int[] TakeFirstN(IEnumerable<int> numbers, int count) =>
        numbers.Take(count).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        int a = ParseInt(valueA);
        int b = ParseInt(valueB);
        return $"{a} % {b} = {Remainder(a, b)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        int count = ParseIntOrDefault(parameterText, 2);
        return $"First {count}: {Format(TakeFirstN(numbers, count))}";
    }

    private static int ParseInt(string text) => int.Parse(text.Trim(), CultureInfo.InvariantCulture);

    private static int ParseIntOrDefault(string text, int defaultValue) =>
        string.IsNullOrWhiteSpace(text) ? defaultValue : ParseInt(text);

    private static double ParseDouble(string text) =>
        double.Parse(text.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);

    private static int[] ParseInts(string text) =>
        text.Split(new[] { ',', ';', ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(ParseInt)
            .ToArray();

    private static string[] ParseStrings(string text) =>
        text.Split(new[] { ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(value => value.Trim())
            .Where(value => value.Length > 0)
            .ToArray();

    private static string Format<T>(IEnumerable<T> values) => string.Join(", ", values);

    private static string FormatGroups(Dictionary<string, int[]> groups) =>
        string.Join(Environment.NewLine, groups.Select(group => $"{group.Key}: {Format(group.Value)}"));
}
