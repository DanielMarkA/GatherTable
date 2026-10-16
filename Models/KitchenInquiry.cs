namespace Sprint.Models;

public class KitchenInquiry
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string GuestId { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public string CategoryBadge { get; set; } = "ALLERGY · Severe"; // "ALLERGY · Severe", "PREFERENCE · Low sodium"
    public bool IsSevere { get; set; }
    public string Title { get; set; } = string.Empty; // e.g. "Alex · Salmon + shared vegetables"
    public string QuestionText { get; set; } = string.Empty;
    public KitchenConfirmationStatus Status { get; set; } = KitchenConfirmationStatus.AwaitingReply;
    public string RequestedTimeLabel { get; set; } = "Requested today at 9:30 AM";
    public string ResponseNote { get; set; } = string.Empty;
}

