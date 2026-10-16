namespace Sprint.Models;

public class GuestCostShare
{
    public string GuestId { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public string GuestInitials { get; set; } = string.Empty;
    public string MainDishName { get; set; } = string.Empty;
    public int MainQuantity { get; set; } = 1;
    public decimal MainCost { get; set; }
    public decimal SharedDishCost { get; set; }
    public decimal FoodSubtotal => MainCost + SharedDishCost;
    public decimal TaxAmount { get; set; }
    public decimal TipAmount { get; set; }
    public decimal TotalAmount => FoodSubtotal + TaxAmount + TipAmount;
}

public class EventFinancialSummary
{
    public decimal FoodSubtotal { get; set; }
    public decimal TaxRate { get; set; } = 0.08m;
    public decimal TaxAmount { get; set; }
    public decimal TipRate { get; set; } = 0.20m;
    public decimal TipAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public int MainCount { get; set; }
    public int SharedCount { get; set; }
    public decimal SharedBowlTotal { get; set; }
    public decimal PerPersonSharedAmount { get; set; }
    public List<GuestCostShare> Shares { get; set; } = new();
}

