using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket24;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Проверка длины коллекции";
    public const string SecondTaskTitle = "Цепочка операций";

    public static bool HasLength<T>(ICollection<T> values, int expectedLength) =>
        values.Count == expectedLength;

    public static int[] ChainOperations(IEnumerable<int> numbers) =>
        numbers.Where(number => number > 0)
            .Where(number => number % 2 == 0)
            .Select(number => number * number)
            .OrderBy(number => number)
            .ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        string[] values = ParseStrings(valueA);
        int expected = ParseIntOrDefault(valueB, values.Length);
        return $"Length equals {expected}: {HasLength(values, expected)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        return $"Positive even squares: {Format(ChainOperations(numbers))}";
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
