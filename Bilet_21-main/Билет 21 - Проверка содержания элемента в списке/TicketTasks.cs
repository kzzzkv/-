using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket21;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Проверка содержания элемента в списке";
    public const string SecondTaskTitle = "Объединение коллекций";

    public static bool ListContainsElement<T>(IEnumerable<T> values, T target) =>
        values.Contains(target);

    public static int[] UnionCollections(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Union(second).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        string[] values = ParseStrings(valueA);
        string target = string.IsNullOrWhiteSpace(valueB) ? "green" : valueB.Trim();
        return $"Contains '{target}': {ListContainsElement(values, target)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] first = ParseInts(valuesText);
        int[] second = string.IsNullOrWhiteSpace(parameterText) ? Array.Empty<int>() : ParseInts(parameterText);
        return $"Union: {Format(UnionCollections(first, second))}";
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
