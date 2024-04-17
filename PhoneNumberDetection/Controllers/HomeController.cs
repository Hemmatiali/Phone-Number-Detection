using Microsoft.AspNetCore.Mvc;
using PhoneNumberDetection.Models;
using PhoneNumberDetection.Interfaces;

namespace PhoneNumberDetection.Controllers;

/// <summary>
///     The HomeController manages the main interactions between user input and the detection of phone numbers.
/// </summary>
public class HomeController : Controller
{
    // Fields
    private readonly IPhoneNumberDetectorServices _detector;


    // Ctor
    public HomeController(IPhoneNumberDetectorServices detector)
    {
        _detector = detector;
    }

    /// <summary>
    ///     Renders the initial home view.
    /// </summary>
    /// <returns>The index view.</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    ///     Processes user input either from a text input or an uploaded file to detect phone numbers.
    /// </summary>
    /// <param name="inputText">Text input containing potential phone numbers.</param>
    /// <param name="file">A file uploaded by the user containing potential phone numbers.</param>
    /// <returns>The index view populated with detected phone numbers or error messages.</returns>
    [HttpPost]
    public IActionResult Index(string inputText, IFormFile file)
    {
        IEnumerable<PhoneNumber> detectedNumbers = null;
        string errorMessage = null;

        try
        {
            if (file != null)
            {
                detectedNumbers = ProcessUploadedFile(file);
            }
            else if (!string.IsNullOrEmpty(inputText))
            {
                detectedNumbers = _detector.DetectPhoneNumbers(inputText);
            }
            else
            {
                errorMessage = "Please enter text or upload a file.";
            }
        }
        catch (Exception ex)
        {
            errorMessage = "An error occurred. Please check your input and try again.";
        }

        return View((detectedNumbers, errorMessage));
    }

    /// <summary>
    ///     Processes the uploaded file to detect unique phone numbers.
    /// </summary>
    /// <param name="file">The file uploaded by the user.</param>
    /// <returns>An enumerable of unique detected phone numbers.</returns>
    private IEnumerable<PhoneNumber> ProcessUploadedFile(IFormFile file)
    {
        try
        {
            var detectedNumbers = new List<PhoneNumber>();
            var numberSet = new HashSet<string>(); // HashSet to track unique numbers

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var numbers = _detector.DetectPhoneNumbers(line.Trim());

                    foreach (var number in numbers)
                    {
                        if (numberSet.Add(number.Number)) // Add returns true if the number is new
                        {
                            detectedNumbers.Add(number);
                        }
                    }
                }
            }
            return detectedNumbers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}