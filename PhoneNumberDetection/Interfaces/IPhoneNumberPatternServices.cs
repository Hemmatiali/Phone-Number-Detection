using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Interfaces;

/// <summary>
///     Provides services for handling and processing phone number patterns.
/// </summary>
public interface IPhoneNumberPatternServices
{
    /// <summary>
    ///     Gets a description of the phone number format.
    /// </summary>
    string FormatDescription { get; }

    /// <summary>
    ///     Gets the Regex used to detect phone numbers.
    /// </summary>
    Regex Regex { get; }

    /// <summary>
    ///     Matches phone number patterns in the provided input text.
    /// </summary>
    /// <param name="input">The text to search for phone numbers.</param>
    /// <returns>A collection of Regex Match objects found within the input text.</returns>
    MatchCollection Match(string input);

    /// <summary>
    ///     Extracts the country code from a matched phone number.
    /// </summary>
    /// <param name="match">A Regex Match object containing a phone number.</param>
    /// <returns>The country code extracted from the phone number, if available.</returns>
    string ExtractCountryCode(Match match);
}