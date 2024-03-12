using System.Linq;
using System.Text;
using Pluralize.Core;

namespace DynaFill.Filler;

public static class StringHelpers
{
    public static string FilterBy(char byChar, string toFilter)
    {
        string filteredString = string.Empty;
        if (toFilter.Length > 0)
        {
            filteredString = toFilter[..toFilter.IndexOf(byChar)];
        }

        return filteredString;
    }

    public static string GetFirstCharToUpper(this string value) =>
            value.ToCharArray().First().ToString().ToUpperInvariant();

    /// <summary>
    /// Gets the first word in an string with no space by Case-Letter
    /// </summary>
    /// <param name="value">String to get word from</param>
    /// <returns>First word in string</returns>
    public static string GetFirstWordByCase(this string value)
    {
        var sb = new StringBuilder();

        foreach (char c in value)
        {
            if (char.IsUpper(c))
            {
                _ = sb.Append(' ');
                _ = sb.Append(c);
            }
            else
            {
                _ = char.IsLower(c) ? sb.Append(c) : sb.Append(value);
            }
        }
        var result = sb.ToString();
        var filteredWord = result.Split(' ').Skip(1).First();
        return filteredWord;
    }

    /// <summary>
    /// Gets the last word in a string without spaces by Case-Letter
    /// </summary>
    /// <param name="value">String to get word from</param>
    /// <returns>Last word in string</returns>
    public static string GetLastWordByCase(this string value)
    {
        var sb = new StringBuilder();

        foreach (char c in value)
        {
            if (char.IsUpper(c))
            {
                _ = sb.Append(' ');
                _ = sb.Append(c);
            }
            else
            {
                _ = char.IsLower(c) ? sb.Append(c) : sb.Append(value);
            }
        }
        var result = sb.ToString();
        var filteredWord = result.Split(' ').Last();
        return filteredWord;
    }

    /// <summary>
    /// Gets the middle word in an unspaced string by Case-Letter
    /// </summary>
    /// <param name="value">String to get word from</param>
    /// <returns>Middle word in string</returns>
    public static string GetMidWordByCase(this string value)
    {
        var sb = new StringBuilder();

        foreach (char c in value)
        {
            if (char.IsUpper(c))
            {
                _ = sb.Append(' ');
                _ = sb.Append(c);
            }
            else
            {
                _ = char.IsLower(c) ? sb.Append(c) : sb.Append(value);
            }
        }
        var result = sb.ToString();
        var filteredWord = result.Split(' ').Skip(2).First();
        return filteredWord;
    }

    public static string IsRequiredError(this string value) =>
             $"{value} Must be provided!";

    /// <summary>
    /// Convert singular string to plural string
    /// </summary>
    /// <param name="value">Singular string</param>
    /// <returns>Plural string</returns>
    public static string ToPlural(this string value) =>
        new Pluralizer().Pluralize(value);

    /// <summary>
    /// Convert plural string to singular
    /// </summary>
    /// <param name="value">Plural string</param>
    /// <returns>Singular string</returns>
    public static string ToSingular(this string value) =>
        new Pluralizer().Singular(value);

    /// <summary>
    /// Convert string to separated words
    /// </summary>
    /// <param name="value">input string</param>
    /// <returns>multi word string</returns>
    public static string ToWords(this string value)
    {
        var sb = new StringBuilder();

        foreach (char c in value)
        {
            if (char.IsUpper(c))
            {
                _ = sb.Append(' ');
                _ = sb.Append(c);
            }
            else if (char.IsDigit(c))
            {
                _ = sb.Append(' ');
                _ = sb.Append(c);
            }
            else
            {
                _ = char.IsLower(c) ? sb.Append(c) : sb.Append(value);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Convert string to camelCase
    /// </summary>
    /// <param name="value">string to convert</param>
    /// <returns>Camel case string</returns>
    public static string ToCamelCase(this string value)
    {
        var sb = new StringBuilder();

        foreach (char c in value)
        {
            if (char.IsUpper(c))
            {
                _ = sb.Append(char.ToLower(c));
            }
            else
            {
                _ = char.IsLower(c) ? sb.Append(c) : sb.Append(value);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Convert to PascalCase
    /// </summary>
    /// <param name="value">string to convert</param>
    /// <returns>Pascal Case string</returns>
    public static string ToPascalCase(this string value)
    {
        var sb = new StringBuilder();

        foreach (char c in value)
        {
            if (char.IsLower(c))
            {
                _ = sb.Append(char.ToUpper(c));
            }
            else
            {
                _ = char.IsUpper(c) ? sb.Append(c) : sb.Append(value);
            }
        }

        return sb.ToString();
    }
}
