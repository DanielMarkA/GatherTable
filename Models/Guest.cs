namespace Sprint.Models;

public class Guest
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Initials { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool IsHost { get; set; }
    public string RoleTitle { get; set; } = "Guest";
    public RsvpStatus Rsvp { get; set; } = RsvpStatus.Going;
    public DietaryProfile DietaryProfile { get; set; } = new();
    public string InviteCode { get; set; } = string.Empty;

    public static string GenerateInitials(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return "??";
        var parts = name.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
        return $"{parts[0][0]}{parts[^1][0]}".ToUpper();
    }
}

