using System.Text.RegularExpressions;
using PhoneNumberDetection.Interfaces;

namespace PhoneNumberDetection.Services;

/// <inheritdoc cref="IPhoneNumberPatternServices"/>
public class TenDigitPatternServices : IPhoneNumberPatternServices
{
    // Fields
    public string FormatDescription => "10-digit";
    public Regex Regex => new(@"^\d{3}-?\d{3}-?\d{4}$");


    // Methods

    /// <inheritdoc />
    public MatchCollection Match(string input) => Regex.Matches(input);

    /// <inheritdoc />
    public string ExtractCountryCode(Match match) => null; // No country code
}