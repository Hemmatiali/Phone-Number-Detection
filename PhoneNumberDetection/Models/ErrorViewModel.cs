namespace PhoneNumberDetection.Models;

/// <summary>
///     Represents the ErrorViewModel class for handling errors in the application.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    ///     Gets or sets the unique identifier for the request.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    ///     Gets a value indicating whether to show the request identifier.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}