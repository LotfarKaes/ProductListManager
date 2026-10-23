// Level 3 - Product Validation
// Only accept LETTERS-NUMBER, for example CE-400. The number must be 200 to 500.

using System.Text.RegularExpressions;

List<string> products = new List<string>();

while (true)
{
    Console.Write("Enter a product name (type 'exit' to finish): ");
    string cleaned = (Console.ReadLine() ?? "exit").Trim();

    if (cleaned.ToLower() == "exit")
    {
        break;
    }

    if (IsValidProduct(cleaned, out string error))
    {
        products.Add(cleaned.ToUpper());
        Console.WriteLine("Product added.");
    }
    else
    {
        Console.WriteLine("Error: " + error);
    }
}

products.Sort(StringComparer.OrdinalIgnoreCase);

Console.WriteLine();
Console.WriteLine("Products (sorted A-Z):");
foreach (string product in products)
{
    Console.WriteLine("- " + product);
}

/// <summary>
/// Checks the format LETTERS-NUMBER and that the number is between 200 and 500.
/// </summary>
/// <param name="input">The trimmed text typed by the user.</param>
/// <param name="error">A message that explains why the input is invalid.</param>
/// <returns>True if the input is a valid product name.</returns>
static bool IsValidProduct(string input, out string error)
{
    // Letters only, one dash, digits only.
    if (!Regex.IsMatch(input, @"^[A-Za-z]+-[0-9]+$"))
    {
        error = "Use the format LETTERS-NUMBER (for example CE-400).";
        return false;
    }

    // Take the part after the dash and convert it safely.
    string numberPart = input.Substring(input.IndexOf('-') + 1);
    if (!int.TryParse(numberPart, out int number))
    {
        error = "The number is not valid.";
        return false;
    }

    if (number < 200 || number > 500)
    {
        error = "The number must be between 200 and 500.";
        return false;
    }

    error = "";
    return true;
}