using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket06;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Возведение в степень";
    public const string SecondTaskTitle = "Пропуск первых N элементов";

    public static double Power(double number, double exponent) => Math.Pow(number, exponent);

    public static int[] SkipFirstN(IEnumerable<int> numbers, int count) =>
        numbers.Skip(count).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double number = ParseDouble(valueA);
        double exponent = ParseDouble(valueB);
        return $"{number}^{exponent} = {Power(number, exponent)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        int count = ParseIntOrDefault(parameterText, 2);
        return $"After skipping {count}: {Format(SkipFirstN(numbers, count))}";
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
