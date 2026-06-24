using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket08;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Абсолютное значение";
    public const string SecondTaskTitle = "Преобразование строк";

    public static double AbsoluteValue(double number) => Math.Abs(number);

    public static string[] TransformStrings(IEnumerable<string> values) =>
        values.Select(value => value.Trim().ToUpperInvariant()).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double number = ParseDouble(valueA);
        return $"abs({number}) = {AbsoluteValue(number)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        string[] values = ParseStrings(valuesText);
        return $"Transformed: {Format(TransformStrings(values))}";
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
