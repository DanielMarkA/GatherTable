namespace Sprint.Models;

public class DiningEvent
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Title { get; set; } = "Studio team dinner";
    public string VenueName { get; set; } = "The Juniper Room";
    public string VenueAddress { get; set; } = "1840 Union St, San Francisco, CA";
    public string VenueMenuLink { get; set; } = "juniperroom.example/menus/dinner";
    public string City { get; set; } = "San Francisco";
    public string TableInfo { get; set; } = "Garden table · 6 guests";
    public DateTime EventDate { get; set; } = new DateTime(2026, 10, 22, 19, 0, 0);
    public string TimeZoneLabel { get; set; } = "Pacific Time (Los Angeles)";
    public string HostNotes { get; set; } = "A little time away from our screens. Join us for a relaxed team dinner — choose something you'll love before we arrive.";
    public string HostName { get; set; } = "Maya Chen";
    public string HostPhone { get; set; } = "(415) 555-0142";
    public string HostEmail { get; set; } = "maya@studio.co";
    public string HostInitials { get; set; } = "MC";
    public DateTime PreOrderDeadline { get; set; } = new DateTime(2026, 10, 20, 17, 0, 0);
    public string ReminderSetting { get; set; } = "24 hours before the deadline";
    public bool AllowGuestUpdates { get; set; } = true;
    public decimal SalesTaxPercent { get; set; } = 8.0m;
    public decimal TipPercent { get; set; } = 20.0m;
    public EventStatus Status { get; set; } = EventStatus.OrdersCollected;
    public string InviteCode { get; set; } = "studio-oct22";
    public string InviteUrl => $"gathertable.app/j/{InviteCode}";
    public List<string> InvitedEmails { get; set; } = new()
    {
        "alex@studio.co",
        "jordan@studio.co",
        "sam@studio.co",
        "priya@studio.co",
        "leo@studio.co"
    };

    public List<Guest> Guests { get; set; } = new();
    public List<MenuItem> Menu { get; set; } = new();
    public List<GuestPreOrder> PreOrders { get; set; } = new();
    public List<KitchenInquiry> KitchenInquiries { get; set; } = new();
}

