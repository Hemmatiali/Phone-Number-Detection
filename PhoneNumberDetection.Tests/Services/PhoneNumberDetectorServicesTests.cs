using PhoneNumberDetection.Services;

namespace PhoneNumberDetection.Tests.Services;

/// <summary>
///     Contains unit tests for the <see cref="PhoneNumberDetectorServices"/> class.
/// </summary>
public class PhoneNumberDetectorServicesTests
{
    /// <summary>
    ///     Tests the DetectPhoneNumbers method with various valid phone numbers containing different patterns.
    /// </summary>
    /// <param name="inputText">The input phone number text.</param>
    /// <param name="expectedNumber">The expected extracted phone number.</param>
    /// <param name="expectedFormat">The expected phone number format.</param>
    [Theory]
    [InlineData("123-456-7890", "123-456-7890", "10-digit")]
    [InlineData("(123) 456-7890", "(123) 456-7890", "With Parentheses")]
    [InlineData("9876543210", "9876543210", "10-digit")]
    [InlineData("0123-4567890", "0123-4567890", "With Flexible Separators")]
    public void DetectPhoneNumbers_ValidNumberWithDifferentPatterns_ReturnsCorrectMatches(string inputText, string expectedNumber, string expectedFormat)
    {
        // Arrange
        var detectorService = new PhoneNumberDetectorServices();

        // Act
        var phoneNumbers = detectorService.DetectPhoneNumbers(inputText);

        // Assert
        Assert.Collection(phoneNumbers,
            phoneNumber =>
            {
                Assert.Equal(expectedNumber, phoneNumber.Number);
                Assert.Equal(expectedFormat, phoneNumber.Format);
                Assert.Null(phoneNumber.CountryCode);
            });
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with an invalid input, expecting no matches.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_InvalidNumber_ReturnsNoMatch()
    {
        // Arrange
        var detectorService = new PhoneNumberDetectorServices();
        var inputText = "This is an invalid input";

        // Act
        var phoneNumbers = detectorService.DetectPhoneNumbers(inputText);

        // Assert
        Assert.Empty(phoneNumbers);
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with number words in English, expecting correct matches.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_NumberWordsEnglish_ReturnsCorrectMatches()
    {
        // Arrange
        var detectorService = new PhoneNumberDetectorServices();
        var inputText = "ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE ZERO";

        // Act
        var phoneNumbers = detectorService.DetectPhoneNumbers(inputText);

        // Assert
        Assert.Collection(phoneNumbers,
            phoneNumber =>
            {
                Assert.Equal("1234567890", phoneNumber.Number);
                Assert.Equal("10-digit", phoneNumber.Format);
                Assert.Null(phoneNumber.CountryCode);
            });
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with number words in Hindi, expecting correct matches.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_NumberWordsHindi_ReturnsCorrectMatches()
    {
        // Arrange
        var detectorService = new PhoneNumberDetectorServices();
        var inputText = "दो दो तीन छह छह छह तीन तीन दो छह";

        // Act
        var phoneNumbers = detectorService.DetectPhoneNumbers(inputText);

        // Assert
        Assert.Collection(phoneNumbers,
            phoneNumber =>
            {
                Assert.Equal("2236663326", phoneNumber.Number);
                Assert.Equal("10-digit", phoneNumber.Format);
                Assert.Null(phoneNumber.CountryCode);
            });
    }

    /// <summary>
    ///     Tests the DetectPhoneNumbers method with number words in Hindi and English, expecting correct matches.
    /// </summary>
    [Fact]
    public void DetectPhoneNumbers_NumberWordsHindiAndEnglish_ReturnsCorrectMatches()
    {
        // Arrange
        var detectorService = new PhoneNumberDetectorServices();
        var inputText = "दो दो तीन six six six तीन तीन दो छह";

        // Act
        var phoneNumbers = detectorService.DetectPhoneNumbers(inputText);

        // Assert
        Assert.Collection(phoneNumbers,
            phoneNumber =>
            {
                Assert.Equal("2236663326", phoneNumber.Number);
                Assert.Equal("10-digit", phoneNumber.Format);
                Assert.Null(phoneNumber.CountryCode);
            });
    }
}