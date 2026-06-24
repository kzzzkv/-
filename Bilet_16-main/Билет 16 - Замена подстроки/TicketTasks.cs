using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket16;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Замена подстроки";
    public const string SecondTaskTitle = "Проверка наличия элемента";

    public static string ReplaceSubstring(string text, string oldValue, string newValue) =>
        text.Replace(oldValue, newValue);

    public static bool ContainsElement(IEnumerable<int> numbers, int target) =>
        numbers.Contains(target);

    public static string RunFirstDemo(string valueA, string valueB)
    {
        string[] parts = valueB.Split('=', 2);
        string oldValue = parts.Length > 0 ? parts[0] : string.Empty;
        string newValue = parts.Length > 1 ? parts[1] : string.Empty;
        return $"Result: {ReplaceSubstring(valueA, oldValue, newValue)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        int target = ParseIntOrDefault(parameterText, 2);
        return $"Contains {target}: {ContainsElement(numbers, target)}";
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
