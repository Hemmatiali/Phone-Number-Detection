# Phone Number Detection Application

Welcome to the Phone Number Detection Application! This C# application is designed to extract and identify phone numbers from a given text input, supporting various formats and providing a robust, user-friendly experience. The code follows best practices, including SOLID principles, and is built with .NET 8.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Examples](#examples)
- [Documentation and Comments](#documentation-and-comments)
- [Constraints](#constraints)
- [License](#license)

## Features

1. **Phone Number Detection:**
   - Detect phone numbers in various formats including:
     - 10-digit numbers (e.g., 123-456-7890)
     - Numbers with country codes (e.g., +1-123-456-7890, +91-1234567890)
     - Numbers with parentheses for area codes (e.g., (91) 1234567890, (123) 456-7890)
     - Numbers with spaces or dashes as separators (e.g., 123 456 7890, 123-456-7890)
     - Combination of English and Hindi numbers (e.g., ONE दो तीन FOUR FIVE छह SEVEN EIGHT NINE दो)

2. **Display Detected Phone Numbers:**
   - Display all detected phone numbers along with their respective formats.
   - Indicate the format of each phone number (e.g., 10-digit, country code, with parentheses, etc.).

3. **User Input:**
   - Accept text input from various sources, such as a text file or direct user input through a console or GUI.

4. **Output Formatting:**
   - Format the output to present detected phone numbers in a clear and readable manner.
   - Include information about the format of each phone number to aid user understanding.

## Installation

To install and run the application, follow these steps:

1. Clone the repository from GitHub:
   ```bash
   git clone https://github.com/Hemmatiali/Phone-Number-Detection.git
   cd Phone-Number-Detection

## Build the Application

Build the application using .NET Core or .NET Framework:

```bash
dotnet build
```

## Run the Application

```bash
dotnet run
```

## Examples

```bash
Detected Phone Numbers:
- 123-456-7890 (10-digit)
- +1-123-456-7890 (Country code)
- (91) 1234567890 (With parentheses)
- 123 456 7890 (10-digit)
- ONE दो तीन FOUR FIVE छह SEVEN EIGHT NINE दो (10-digit)
```

## Documentation and Comments

The code is thoroughly documented with comments explaining the functionality of each component and method. Clear instructions are provided on how to build, run, and use the application.

## License
This project is licensed under the MIT License - see the [LICENSE](license.txt) file for details.
