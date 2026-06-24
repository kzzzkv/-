using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ticket10;

public static class TicketTasks
{
    public const string FirstTaskTitle = "Округление";
    public const string SecondTaskTitle = "Объединение строк";

    public static double RoundNumber(double number, int digits = 0) => Math.Round(number, digits);

    public static string JoinStrings(IEnumerable<string> values, string separator) =>
        string.Join(separator, values);

    public static string RunFirstDemo(string valueA, string valueB)
    {
        double number = ParseDouble(valueA);
        int digits = ParseIntOrDefault(valueB, 0);
        return $"round({number}, {digits}) = {RoundNumber(number, digits)}";
    }

    public static string RunSecondDemo(string valuesText, string parameterText)
    {
        string[] values = ParseStrings(valuesText);
        string separator = string.IsNullOrEmpty(parameterText) ? " " : parameterText;
        return $"Joined: {JoinStrings(values, separator)}";
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
