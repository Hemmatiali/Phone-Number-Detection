using PhoneNumberDetection.Models;

namespace PhoneNumberDetection.Interfaces;

/// <summary>
///    Methods for detecting phone numbers in text.
/// </summary>
public interface IPhoneNumberDetectorServices
{
    /// <summary>
    ///     Detects phone numbers within the provided input text and returns them as a collection of PhoneNumber objects.
    /// </summary>
    /// <param name="inputText">The text to analyze for phone numbers.</param>
    /// <returns>A collection of detected phone numbers.</returns>
    IEnumerable<PhoneNumber> DetectPhoneNumbers(string inputText);
}