using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket20;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Проверка массива на пустоту";
    public const string SecondTaskTitle = "Удаление дубликатов";

    public static bool IsArrayEmpty<T>(IEnumerable<T> values) => !values.Any();

    public static int[] RemoveDuplicates(IEnumerable<int> numbers) =>
        numbers.Distinct().ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        int[] numbers = string.IsNullOrWhiteSpace(valueA) ? Array.Empty<int>() : ParseInts(valueA);
        return $"Array is empty: {IsArrayEmpty(numbers)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        return $"Without duplicates: {Format(RemoveDuplicates(numbers))}";
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
