using PhoneNumberDetection.Interfaces;
using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Services;

/// <inheritdoc cref="IPhoneNumberPatternServices"/>
public class ParenthesesPatternServices : IPhoneNumberPatternServices
{
    // Fields
    public string FormatDescription => "With Parentheses";
    public Regex Regex => new(@"(\(\d{3}\))[- ]?(\d{3})[- ]?(\d{4})");

    /// <inheritdoc />
    public MatchCollection Match(string input) => Regex.Matches(input);

    /// <inheritdoc />
    public string ExtractCountryCode(Match match)
    {
        return null; // Parenthesized numbers typically don't have country codes
    }
}