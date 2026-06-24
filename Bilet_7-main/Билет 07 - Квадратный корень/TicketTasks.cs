using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket07;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Квадратный корень";
    public const string SecondTaskTitle = "Фильтрация строк по длине";

    public static double SquareRoot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be non-negative.");
        }

        return Math.Sqrt(number);
    }

    public static string[] FilterStringsByLength(IEnumerable<string> values, int minLength) =>
        values.Where(value => value.Length >= minLength).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double number = ParseDouble(valueA);
        return $"sqrt({number}) = {SquareRoot(number)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        string[] values = ParseStrings(valuesText);
        int minLength = ParseIntOrDefault(parameterText, 4);
        return $"Length >= {minLength}: {Format(FilterStringsByLength(values, minLength))}";
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
