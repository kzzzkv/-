using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket19;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Содержание подстроки";
    public const string SecondTaskTitle = "Группировка по критерию";

    public static bool ContainsSubstring(string text, string substring) =>
        text.Contains(substring, StringComparison.OrdinalIgnoreCase);

    public static Dictionary<string, int[]> GroupByEvenOdd(IEnumerable<int> numbers) =>
        numbers.GroupBy(number => number % 2 == 0 ? "Even" : "Odd")
            .ToDictionary(group => group.Key, group => group.ToArray());

    public static string RunFirstDemo(string valueA, string valueB)
    {
        return $"Contains '{valueB}': {ContainsSubstring(valueA, valueB)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        return FormatGroups(GroupByEvenOdd(numbers));
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
