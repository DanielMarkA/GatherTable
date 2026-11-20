using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Text.Json.Serialization;

namespace Sprint.Models;

[Table("menu_items")]
public class MenuItem : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("price")]
    public decimal Price { get; set; }

    [Column("category")]
    public string Category { get; set; } = "Main"; // "Main", "SharedSide", "Appetizer"

    [Column("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    [Column("ingredients")]
    public string IngredientsText { get; set; } = string.Empty;

    [Column("declared_allergens")]
    public string DeclaredAllergensText { get; set; } = string.Empty;

    [Column("is_shared_dish")]
    public bool IsSharedDish { get; set; }

    [Column("default_shared_quantity")]
    public int DefaultSharedQuantity { get; set; } = 1;

    [Column("default_prep_note")]
    public string DefaultPrepNote { get; set; } = string.Empty;

    [Column("serving_note")]
    public string ServingNote { get; set; } = string.Empty; // e.g. "2 bowls · Shared by all 6"

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Helper properties for UI compatibility
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [JsonPropertyName("client_ingredients")]
    public List<string> Ingredients
    {
        get => string.IsNullOrWhiteSpace(IngredientsText)
            ? new List<string>()
            : IngredientsText.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
        set => IngredientsText = string.Join(", ", value);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [JsonPropertyName("client_declared_allergens")]
    public List<string> DeclaredAllergens
    {
        get => string.IsNullOrWhiteSpace(DeclaredAllergensText)
            ? new List<string>()
            : DeclaredAllergensText.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
        set => DeclaredAllergensText = string.Join(", ", value);
    }
}
