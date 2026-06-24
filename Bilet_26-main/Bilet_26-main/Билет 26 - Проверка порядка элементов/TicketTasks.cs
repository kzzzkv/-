using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket26;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Проверка порядка элементов";
    public const string SecondTaskTitle = "Проверка любого элемента";

    public static bool IsAscending(IEnumerable<int> numbers)
    {
        int[] array = numbers.ToArray();
        return array.Zip(array.Skip(1), (left, right) => left <= right).All(result => result);
    }

    public static bool HasAnyGreaterThan(IEnumerable<int> numbers, int threshold) =>
        numbers.Any(number => number > threshold);

    public static string RunFirstDemo(string valueA, string valueB)
    {
        int[] numbers = ParseInts(valueA);
        return $"Ascending order: {IsAscending(numbers)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        int threshold = ParseIntOrDefault(parameterText, 5);
        return $"Any greater than {threshold}: {HasAnyGreaterThan(numbers, threshold)}";
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
