using PhoneNumberDetection.Interfaces;
using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Services;

/// <inheritdoc cref="IPhoneNumberPatternServices"/>
public class CountryCodePatternServices : IPhoneNumberPatternServices
{
    // Fields
    public string FormatDescription => "With Country Code";
    public Regex Regex => new(@"(\+\d{1,3})[- ]?(\d{3})[- ]?(\d{3})[- ]?(\d{4})");

    // Methods

    /// <inheritdoc />
    public MatchCollection Match(string input) => Regex.Matches(input);

    /// <inheritdoc />
    public string ExtractCountryCode(Match match)
    {
        if (match is { Success: true, Groups.Count: > 1 })
        {
            return match.Groups[1].Value; // Extract the first capture group (country code)
        }
        else
        {
            return ""; // No match or no capture groups, return empty string
        }
    }

}