using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket04;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Деление";
    public const string SecondTaskTitle = "Сортировка по убыванию";

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Second number must not be zero.");
        }

        return a / b;
    }

    public static int[] SortDescending(IEnumerable<int> numbers) =>
        numbers.OrderByDescending(number => number).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double a = ParseDouble(valueA);
        double b = ParseDouble(valueB);
        return $"{a} / {b} = {Divide(a, b)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        return $"Descending: {Format(SortDescending(numbers))}";
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
