using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket09;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Абсолютное значение отрицательного числа";
    public const string SecondTaskTitle = "Поиск строк по началу";

    public static double AbsoluteNegativeNumber(double number) => Math.Abs(number);

    public static string[] FindStringsByPrefix(IEnumerable<string> values, string prefix) =>
        values.Where(value => value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double number = ParseDouble(valueA);
        return $"abs({number}) = {AbsoluteNegativeNumber(number)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        string[] values = ParseStrings(valuesText);
        string prefix = string.IsNullOrWhiteSpace(parameterText) ? "ap" : parameterText.Trim();
        return $"Starts with '{prefix}': {Format(FindStringsByPrefix(values, prefix))}";
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
