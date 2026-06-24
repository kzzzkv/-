using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket15;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Обрезка пробелов";
    public const string SecondTaskTitle = "Количество элементов";

    public static string TrimSpaces(string text) => text.Trim();

    public static int CountElements<T>(IEnumerable<T> values) => values.Count();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        return $"Trimmed: '{TrimSpaces(valueA)}'";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        string[] values = ParseStrings(valuesText);
        return $"Count: {CountElements(values)}";
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
