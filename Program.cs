// Level 2 - Sorting & Improved Exit Handling
// "exit" works in any case and with extra spaces. The list is sorted before display.

List<string> products = new List<string>();

while (true)
{
    Console.Write("Enter a product name (type 'exit' to finish): ");
    string? input = Console.ReadLine();

    // Trim() removes spaces at the start and end; ToLower() ignores upper/lower case.
    string cleaned = (input ?? "exit").Trim();

    if (cleaned.ToLower() == "exit")
    {
        break;
    }

    // Ignore empty lines so we do not store blank products.
    if (cleaned.Length == 0)
    {
        continue;
    }

    products.Add(cleaned);
}

// Sort alphabetically, ignoring upper/lower case.
products.Sort(StringComparer.OrdinalIgnoreCase);

Console.WriteLine();
Console.WriteLine("Products (sorted A-Z):");
foreach (string product in products)
{
    Console.WriteLine("- " + product);
}