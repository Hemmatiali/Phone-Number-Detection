using PhoneNumberDetection.Models;
using System.Text.RegularExpressions;
using PhoneNumberDetection.Interfaces;
using System.Diagnostics;

namespace PhoneNumberDetection.Services;

/// <inheritdoc cref="IPhoneNumberDetectorServices"/>
public class PhoneNumberDetectorServices : IPhoneNumberDetectorServices
{
    #region Fields

    private readonly IEnumerable<IPhoneNumberPatternServices> _patterns = new List<IPhoneNumberPatternServices> {
                                                                              new TenDigitPatternServices(),
                                                                              new CountryCodePatternServices(),
                                                                              new ParenthesesPatternServices(),
                                                                              new FlexiblePatternServices()
                                                                          }
                                                                          ?? throw new ArgumentNullException("Invalid pattern matching.");
    private readonly Dictionary<string, string> _englishNumberMap = new()
    {
        { "ZERO", "0" },
        { "ONE", "1" },
        { "TWO", "2" },
        { "THREE", "3" },
        { "FOUR", "4" },
        { "FIVE", "5" },
        { "SIX", "6" },
        { "SEVEN", "7" },
        { "EIGHT", "8" },
        { "NINE", "9" }
    };

    private readonly Dictionary<string, string> _hindiNumberMap = new()
    {
        { "शूँय", "0" },
        { "एक", "1" },
        { "दो", "2" },
        { "तीन", "3" },
        { "चार", "4" },
        { "पांच", "5" },
        { "छह", "6" },
        { "सात", "7" },
        { "आठ", "8" },
        { "नौ", "9" }
    };


    #endregion

    #region Methods

    /// <inheritdoc />
    public IEnumerable<PhoneNumber> DetectPhoneNumbers(string inputText)
    {
        var stopwatch = Stopwatch.StartNew(); // Start timing - performance calculation

        // Check if input contains any potential number words (English or Hindi)
        string[] inputWords = inputText.Split(' ');
        bool hasNumberWords = inputWords.Any(word => _englishNumberMap.ContainsKey(word.ToUpper()) || _hindiNumberMap.ContainsKey(word.ToUpper()));

        if (hasNumberWords)
        {
            // Translate if number words are present
            var translatedInput = TranslateNumberWords(inputText);
            foreach (var pattern in _patterns)
            {
                var matches = pattern.Match(translatedInput);
                foreach (Match match in matches)
                {
                    yield return new PhoneNumber
                    {
                        Number = match.Value,
                        Format = pattern.FormatDescription,
                        CountryCode = pattern.ExtractCountryCode(match)
                    };

                    // Exit the loops early if a pattern is matched
                    break;
                }
                if (matches.Count > 0) { break; } // Exit the pattern loop if a match is found
            }
        }
        else
        {
            foreach (var pattern in _patterns)
            {
                var matches = pattern.Match(inputText);
                foreach (Match match in matches)
                {
                    yield return new PhoneNumber
                    {
                        Number = match.Value,
                        Format = pattern.FormatDescription,
                        CountryCode = pattern.ExtractCountryCode(match)
                    };

                    // Exit the loops early if a pattern is matched
                    break;
                }
                if (matches.Count > 0) { break; } // Exit the pattern loop if a match is found
            }
        }
        stopwatch.Stop();
        // Get elapsed time as a TimeSpan
        TimeSpan elapsedTime = TimeSpan.FromTicks(stopwatch.ElapsedTicks);

        // Format and display the output
        Console.WriteLine($"Process Time: " +
                          $"{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}." +
                          $"{elapsedTime.Milliseconds:000} {elapsedTime.Ticks * 100:000000}ns");
    }


    /// <summary>
    ///     Translates number words within the input text into their corresponding numerical representations.
    /// </summary>
    /// <param name="inputText">The text containing number words to be translated.</param>
    /// <returns>The input text with number words replaced by their numerical equivalents.</returns>
    private string TranslateNumberWords(string inputText)
    {
        var tokens = inputText.Split(' ');
        var translatedTokens = new List<string>();

        foreach (var token in tokens)
        {
            if (_englishNumberMap.TryGetValue(token.ToUpper(), out var translatedDigit))
            {
                translatedTokens.Add(translatedDigit);
            }
            else if (_hindiNumberMap.TryGetValue(token, out translatedDigit))
            {
                translatedTokens.Add(translatedDigit);
            }
            else
            {
                translatedTokens.Add(token); // Keep non-number words as is
            }
        }

        return string.Join("", translatedTokens);
    }

    #endregion

}