namespace Sprint.Models;

public class FoodAllergy
{
    public string Allergen { get; set; } = string.Empty;
    public AllergySeverity Severity { get; set; } = AllergySeverity.Moderate;
    public string Details { get; set; } = string.Empty;
}

public class DietaryProfile
{
    public List<FoodAllergy> Allergies { get; set; } = new();
    public List<string> Preferences { get; set; } = new(); // e.g. "Vegetarian", "Low sodium"
    public string Notes { get; set; } = string.Empty;

    public string Summary
    {
        get
        {
            var parts = new List<string>();
            foreach (var a in Allergies)
            {
                parts.Add($"{a.Allergen} allergy · {a.Severity.ToString().ToLower()}");
            }
            foreach (var p in Preferences)
            {
                parts.Add($"{p}");
            }
            return parts.Count > 0 ? string.Join(", ", parts) : "No restrictions";
        }
    }

    public bool HasSevereAllergy => Allergies.Any(a => a.Severity == AllergySeverity.Severe);
    public bool HasAllergies => Allergies.Count > 0;
    public bool HasPreferences => Preferences.Count > 0;
}

