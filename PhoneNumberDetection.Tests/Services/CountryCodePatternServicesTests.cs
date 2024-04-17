using PhoneNumberDetection.Services;

namespace PhoneNumberDetection.Tests.Services;

/// <summary>
///     Contains unit tests for the <see cref="CountryCodePatternServices"/>> class.
/// </summary>
public class CountryCodePatternServicesTests
{
    /// <summary>
    ///     Tests the DetectPhoneNumbers method with a valid phone number including a country code.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_ValidNumberWithCountryCode_ReturnsMatch()
    {
        // Arrange
        var patternService = new CountryCodePatternServices();
        var inputText = "+1-555-123-4567";

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(inputText, matches[0].Value);
        Assert.Equal("+1", matches[0].Groups[1].Value);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with various valid phone numbers including different country codes.
    /// </summary>
    [Theory]
    [InlineData("+91 123 456 7890", "+91")]
    [InlineData("+44-124-567-2890", "+44")]
    public void DetectPhoneNumbers_VariousCountryCodes_CorrectExtraction(string input, string expectedCountryCode)
    {
        // Arrange
        var patternService = new CountryCodePatternServices();

        // Act
        var matches = patternService.Match(input);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(expectedCountryCode, matches[0].Groups[1].Value);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with an invalid phone number missing the country code.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_InvalidNumber_ReturnsNoMatch()
    {
        // Arrange
        var patternService = new CountryCodePatternServices();
        var inputText = "555-123-4567"; // Missing country code

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.Empty(matches);
    }

    /// <summary>
    ///     Tests the ExtractCountryCode method with an empty match, expecting an empty string as a result.
    /// </summary>
    [Fact]
    public void ExtractCountryCode_EmptyMatch_ReturnsEmptyString()
    {
        // Arrange
        var patternService = new CountryCodePatternServices();
        var inputText = ""; // Empty string
        var matchCollection = patternService.Match(inputText); // Empty match collection

        // Act
        string countryCode = "";
        if (matchCollection.Count > 0)
        {
            countryCode = patternService.ExtractCountryCode(matchCollection[0]);
        }

        // Assert
        Assert.Equal("", countryCode);
    }


    /// <summary>
    ///     Tests the DetectPhoneNumbers method with various valid phone numbers including different formats.
    /// </summary>
    [Theory]
    [InlineData("+91 1234567890")]
    [InlineData("+44 124-567-2890")]
    public void DetectPhoneNumbers_ValidNumberWithDifferentFormats_ReturnsMatch(string inputText)
    {
        // Arrange
        var patternService = new CountryCodePatternServices();

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(inputText, matches[0].Value);
    }

}