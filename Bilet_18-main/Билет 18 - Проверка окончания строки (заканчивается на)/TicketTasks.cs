using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket18;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Проверка окончания строки (заканчивается на)";
    public const string SecondTaskTitle = "Проверка любого элемента";

    public static bool EndsWithText(string text, string suffix) =>
        text.EndsWith(suffix, StringComparison.OrdinalIgnoreCase);

    public static bool HasAnyPositive(IEnumerable<int> numbers) =>
        numbers.Any(number => number > 0);

    public static string RunFirstDemo(string valueA, string valueB)
    {
        return $"Ends with '{valueB}': {EndsWithText(valueA, valueB)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        return $"Any positive: {HasAnyPositive(numbers)}";
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
