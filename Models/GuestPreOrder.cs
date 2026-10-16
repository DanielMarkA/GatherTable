namespace Sprint.Models;

public class GuestPreOrder
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string GuestId { get; set; } = string.Empty;
    public string MenuItemId { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public List<string> Modifications { get; set; } = new();
    public string KitchenNote { get; set; } = string.Empty;
    public string SpecialPrepSummary { get; set; } = string.Empty; // e.g. "Vegetarian stock; no Parmesan"
    public bool IsSaved { get; set; } = true;
    public DateTime? SavedAt { get; set; } = DateTime.Now;
    public bool HasKitchenPending { get; set; }
}

