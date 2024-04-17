using PhoneNumberDetection.Services;
using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Tests.Services;

/// <summary>
///     Contains unit tests for the <see cref="FlexiblePatternServices"/> class.
/// </summary>
public class FlexiblePatternServicesTests
{
    /// <summary>
    ///     Tests the DetectPhoneNumbers method with various phone numbers containing different separators.
    /// </summary>
    /// <param name="inputText">The input phone number text.</param>
    [Theory]
    [InlineData("123-456-7890")]
    [InlineData("123 456 7890")]
    [InlineData("1234567890")] // Assuming this is a valid format
    public void DetectPhoneNumbers_VariousSeparators_ReturnsMatch(string inputText)
    {
        // Arrange
        var patternService = new FlexiblePatternServices();

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(inputText, matches[0].Value);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with an invalid phone number format, expecting no matches.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_InvalidNumber_ReturnsNoMatch()
    {
        // Arrange
        var patternService = new FlexiblePatternServices();
        var inputText = "12-345-67890"; // Invalid format

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.Empty(matches);
    }

    /// <summary>
    ///     Tests the ExtractCountryCode method with a null match, expecting a null result.
    /// </summary>
    [Fact]
    public void ExtractCountryCode_NullMatch_ReturnsNull()
    {
        // Arrange
        var patternService = new FlexiblePatternServices();
        Match nullMatch = null; // Simulate null match

        // Act
        var countryCode = patternService.ExtractCountryCode(nullMatch);

        // Assert
        Assert.Null(countryCode);
    }
}