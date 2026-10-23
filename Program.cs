// Level 1 - Basic Product Input
// Ask for product names, store them in a list, show them when the user types "exit".

List<string> products = new List<string>();

while (true)
{
    Console.Write("Enter a product name (type 'exit' to finish): ");
    string? input = Console.ReadLine();

    // ReadLine returns null if the input stream is closed, so stop in that case too.
    if (input == null || input == "exit")
    {
        break;
    }

    products.Add(input);
}

Console.WriteLine();
Console.WriteLine("Products:");
foreach (string product in products)
{
    Console.WriteLine("- " + product);
}