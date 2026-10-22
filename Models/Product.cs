
using System.Text.Json.Serialization;

namespace ProductListManager.Models;

/// <summary>
/// Represents a single product in the format LETTERS-NUMBER (for example "CE-400").
/// Declared as a record so two products with the same values are considered equal.
/// </summary>
/// <param name="Prefix">The letters part of the product name (stored in upper case).</param>
/// <param name="Number">The numeric part of the product name (200-500).</param>

public sealed record Product(string Prefix, int Number)
{
    /// <summary>
    /// The full product name, e.g. "CE-400". Not serialized because it is
    /// always rebuilt from <see cref="Prefix"/> and <see cref="Number"/>.
    /// </summary>
    [JsonIgnore]
    public string Code => $"{Prefix}-{Number}";

    /// <summary>Returns the full product name so the object prints nicely.</summary>
    public override string ToString() => Code;
}