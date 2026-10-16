namespace Sprint.Models;

public enum RsvpStatus
{
    Pending,
    Going,
    CantMakeIt
}

public enum AllergySeverity
{
    Mild,
    Moderate,
    Severe
}

public enum CompatibilityType
{
    NoConflict,
    IngredientConflict,
    CrossContactRisk,
    RecipeModification
}

public enum KitchenConfirmationStatus
{
    AwaitingReply,
    Confirmed,
    CannotAccommodate
}

public enum EventStatus
{
    Draft,
    Active,
    OrdersCollected,
    TicketSent
}

