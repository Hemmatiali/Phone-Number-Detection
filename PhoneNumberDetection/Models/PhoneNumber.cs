namespace PhoneNumberDetection.Models;

/// <summary>
///     Represents a telephone number, including its format and country code.
/// </summary>
public class PhoneNumber
{
    /// <summary>
    ///     Gets or sets the telephone number as a string.
    /// </summary>
    public string Number { get; set; } = "";

    /// <summary>
    ///     Gets or sets the format of the telephone number.
    /// </summary>
    public string Format { get; set; } = "";

    /// <summary>
    ///     Gets or sets the country code associated with the telephone number.
    /// </summary>
    public string CountryCode { get; set; } = "";
}