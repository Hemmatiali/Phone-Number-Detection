using PhoneNumberDetection.Services;
using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Tests.Services;

/// <summary>
///     Contains unit tests for the <see cref="ParenthesesPatternServices"/>> class.
/// </summary>
public class ParenthesesPatternServicesTests
{
    /// <summary>
    ///     Tests the DetectPhoneNumbers method with a valid phone number containing parentheses.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_ValidNumberWithParentheses_ReturnsMatch()
    {
        // Arrange
        var patternService = new ParenthesesPatternServices();
        var inputText = "(123) 456-7890";

        // Act
        var matches = patternService.Match(inputText);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(inputText, matches[0].Value);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with various valid phone numbers containing different parentheses formats.
    /// </summary>
    [Theory]
    [InlineData("(987)654 3210", "(987)")]
    [InlineData("(111)-222-3333", "(111)")]
    public void DetectPhoneNumbers_Variations_CorrectlyMatches(string input, string expectedAreaCode)
    {
        // Arrange
        var patternService = new ParenthesesPatternServices();

        // Act
        var matches = patternService.Match(input);

        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(expectedAreaCode, matches[0].Groups[1].Value);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with an invalid phone number missing parentheses.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_InvalidNumber_ReturnsNoMatch()
    {
        // Arrange
        var patternService = new ParenthesesPatternServices();
        var inputText = "123-456-7890"; // Missing parentheses

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
        var patternService = new ParenthesesPatternServices();
        Match nullMatch = null; // Simulate null match

        // Act
        var countryCode = patternService.ExtractCountryCode(nullMatch);

        // Assert
        Assert.Null(countryCode);
    }
}