using PhoneNumberDetection.Services;

namespace PhoneNumberDetection.Tests.Services;

/// <summary>
///     Contains unit tests for the <see cref="TenDigitPatternServices"/>> class.
/// </summary>
public class TenDigitPatternServicesTests
{
    /// <summary>
    ///     Tests the DetectPhoneNumbers method with a valid 10-digit phone number.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_Valid10DigitNumber_ReturnsMatch()
    {
        // Arrange
        var patternService = new TenDigitPatternServices();
        var inputText = "123-456-7890";

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(inputText, matches[0].Value);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with an invalid phone number format.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_InvalidNumber_ReturnsNoMatch()
    {
        // Arrange
        var patternService = new TenDigitPatternServices();
        var inputText = "123-456"; // Invalid format

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.Empty(matches);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with a valid 10-digit phone number without hyphens.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_ValidNumberWithNoHyphens_ReturnsMatch()
    {
        // Arrange
        var patternService = new TenDigitPatternServices();
        var inputText = "1234567890";

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(inputText, matches[0].Value);
    }

    /// <summary>
    ///     Tests the ExtractCountryCode method when no country code is present.
    /// </summary>
    [Fact]
    public void ExtractCountryCode_NoCountryCode_ReturnsNull()
    {
        // Arrange
        var patternService = new TenDigitPatternServices();
        var inputText = "123-456-7890";
        var match = patternService.Match(inputText)[0]; // Assuming a valid match

        // Act
        var countryCode = patternService.ExtractCountryCode(match);

        // Assert
        Assert.Null(countryCode);
    }
}