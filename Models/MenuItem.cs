namespace Sprint.Models;

public class MenuItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = "Main"; // "Main", "SharedSide", "Appetizer"
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> Ingredients { get; set; } = new();
    public List<string> DeclaredAllergens { get; set; } = new(); // "fish", "mustard", "shellfish", "dairy", etc.
    public bool IsSharedDish { get; set; }
    public int DefaultSharedQuantity { get; set; } = 1;
    public string DefaultPrepNote { get; set; } = string.Empty;
    public string ServingNote { get; set; } = string.Empty; // e.g. "2 bowls · Shared by all 6"
}

