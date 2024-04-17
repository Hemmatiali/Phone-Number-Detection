using PhoneNumberDetection.Interfaces;
using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Services;

/// <inheritdoc cref="IPhoneNumberPatternServices"/>
public class FlexiblePatternServices: IPhoneNumberPatternServices
{
    // Fields
    public string FormatDescription => "With Flexible Separators";
    public Regex Regex => new(@"^(?:\(?(\d{1,3})\)?[-\s]?)?(\d{1,4})[-\s]?(\d{3})[-\s]?(\d{4})$");

    /// <inheritdoc />
    public MatchCollection Match(string input) => Regex.Matches(input);

    /// <inheritdoc />
    public string ExtractCountryCode(Match match)
    {
        return null; // Assumes flexible patterns don't usually have country codes
    }
}