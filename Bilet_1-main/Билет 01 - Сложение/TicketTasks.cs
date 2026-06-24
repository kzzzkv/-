using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket01;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Сложение";
    public const string SecondTaskTitle = "Фильтрация четных чисел";

    public static double Add(double a, double b) => a + b;

    public static int[] FilterEvenNumbers(IEnumerable<int> numbers) =>
        numbers.Where(number => number % 2 == 0).ToArray();

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double a = ParseDouble(valueA);
        double b = ParseDouble(valueB);
        return $"{a} + {b} = {Add(a, b)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        int[] numbers = ParseInts(valuesText);
        return $"Even numbers: {Format(FilterEvenNumbers(numbers))}";
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
