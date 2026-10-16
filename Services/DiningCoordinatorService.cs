using Sprint.Models;

namespace Sprint.Services;

public class DiningCoordinatorService
{
    public DiningEvent CurrentEvent { get; private set; } = null!;
    public event Action? OnChange;

    public DiningCoordinatorService()
    {
        InitializeSeedData();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

    public void InitializeSeedData()
    {
        var ev = new DiningEvent
        {
            Id = "evt-studio-dinner",
            Title = "Studio team dinner",
            VenueName = "The Juniper Room",
            VenueAddress = "1840 Union St, San Francisco, CA",
            VenueMenuLink = "juniperroom.example/menus/dinner",
            City = "San Francisco",
            TableInfo = "Garden table · 6 guests",
            EventDate = new DateTime(2026, 10, 22, 19, 0, 0),
            TimeZoneLabel = "Pacific Time (Los Angeles)",
            HostNotes = "A little time away from our screens. Join us for a relaxed team dinner — choose something you'll love before we arrive.",
            HostName = "Maya Chen",
            HostPhone = "(415) 555-0142",
            HostEmail = "maya@studio.co",
            HostInitials = "MC",
            PreOrderDeadline = new DateTime(2026, 10, 20, 17, 0, 0),
            ReminderSetting = "24 hours before the deadline",
            AllowGuestUpdates = true,
            SalesTaxPercent = 8.0m,
            TipPercent = 20.0m,
            Status = EventStatus.OrdersCollected,
            InviteCode = "studio-oct22"
        };

        // Seed Menu
        var risotto = new MenuItem
        {
            Id = "dish-risotto",
            Name = "Mushroom risotto",
            Description = "Arborio rice, wild mushrooms, stock, Parmesan.",
            Price = 24.00m,
            Category = "Main",
            ImageUrl = "https://images.unsplash.com/photo-1633964913295-ceb43826e7c9?w=600&auto=format&fit=crop&q=80",
            Ingredients = new() { "Arborio rice", "Wild mushrooms", "Vegetable or chicken stock", "Parmesan" },
            DeclaredAllergens = new() { "dairy" },
            DefaultPrepNote = "Arborio rice, wild mushrooms, stock, Parmesan."
        };

        var chicken = new MenuItem
        {
            Id = "dish-chicken",
            Name = "Herb-roasted chicken",
            Description = "Roasted chicken, potatoes, herb jus.",
            Price = 28.00m,
            Category = "Main",
            ImageUrl = "https://images.unsplash.com/photo-1598103442097-8b74394b95c6?w=600&auto=format&fit=crop&q=80",
            Ingredients = new() { "Roasted chicken", "Potatoes", "Herb jus", "Salt" },
            DeclaredAllergens = new() { "poultry" },
            DefaultPrepNote = "Roasted chicken, potatoes, herb jus."
        };

        var salmon = new MenuItem
        {
            Id = "dish-salmon",
            Name = "Citrus salmon",
            Description = "Salmon, lemon, olive oil, dill, greens.",
            Price = 32.00m,
            Category = "Main",
            ImageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288?w=600&auto=format&fit=crop&q=80",
            Ingredients = new() { "Salmon", "Lemon", "Olive oil", "Dill", "Mixed greens", "Dijon mustard", "Salt" },
            DeclaredAllergens = new() { "fish", "mustard" },
            DefaultPrepNote = "Roasted salmon with lemon, dill, olive oil and dressed seasonal greens."
        };

        var veggies = new MenuItem
        {
            Id = "dish-veggies",
            Name = "Roasted vegetables",
            Description = "Seasonal carrots, squash, olive oil, herbs.",
            Price = 12.00m,
            Category = "SharedSide",
            ImageUrl = "https://images.unsplash.com/photo-1540420773420-3366772f4999?w=600&auto=format&fit=crop&q=80",
            Ingredients = new() { "Seasonal carrots", "Squash", "Olive oil", "Fresh herbs" },
            DeclaredAllergens = new(),
            IsSharedDish = true,
            DefaultSharedQuantity = 2,
            ServingNote = "2 bowls · Shared by all 6"
        };

        var shrimpToast = new MenuItem
        {
            Id = "dish-shrimp",
            Name = "Shrimp toast",
            Description = "Shrimp, sourdough, aioli.",
            Price = 14.00m,
            Category = "Appetizer",
            ImageUrl = "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?w=600&auto=format&fit=crop&q=80",
            Ingredients = new() { "Shrimp", "Sourdough", "Aioli", "Sesame" },
            DeclaredAllergens = new() { "shellfish", "gluten", "egg", "sesame" },
            DefaultPrepNote = "Shrimp, sourdough, aioli · 0 selected"
        };

        ev.Menu = new() { risotto, chicken, salmon, veggies, shrimpToast };

        // Seed Guests
        var maya = new Guest
        {
            Id = "guest-maya",
            Name = "Maya Chen",
            Email = "maya@studio.co",
            Initials = "MC",
            IsHost = true,
            RoleTitle = "Host · Studio team",
            Rsvp = RsvpStatus.Going,
            InviteCode = "studio-oct22",
            DietaryProfile = new DietaryProfile
            {
                Preferences = new() { "Vegetarian" },
                Notes = "Vegetarian stock and no Parmesan please."
            }
        };

        var alex = new Guest
        {
            Id = "guest-alex",
            Name = "Alex Rivera",
            Email = "alex@studio.co",
            Initials = "AR",
            IsHost = false,
            Rsvp = RsvpStatus.Going,
            InviteCode = "alex-r",
            DietaryProfile = new DietaryProfile
            {
                Allergies = new()
                {
                    new FoodAllergy
                    {
                        Allergen = "Shellfish",
                        Severity = AllergySeverity.Severe,
                        Details = "Severe reaction, including breathing difficulty. Cross-contact precautions are essential."
                    }
                },
                Notes = "I carry epinephrine. Please use a separate pan, clean utensils and a separate prep area away from shellfish."
            }
        };

        var jordan = new Guest
        {
            Id = "guest-jordan",
            Name = "Jordan Lee",
            Email = "jordan@studio.co",
            Initials = "JL",
            IsHost = false,
            Rsvp = RsvpStatus.Going,
            InviteCode = "jordan-l",
            DietaryProfile = new DietaryProfile
            {
                Preferences = new() { "Low sodium" },
                Notes = "Can the chicken and vegetables be made without added salt, with unsalted stock and sauce on the side?"
            }
        };

        var sam = new Guest
        {
            Id = "guest-sam",
            Name = "Sam Patel",
            Email = "sam@studio.co",
            Initials = "SP",
            IsHost = false,
            Rsvp = RsvpStatus.Going,
            InviteCode = "sam-p",
            DietaryProfile = new DietaryProfile()
        };

        var priya = new Guest
        {
            Id = "guest-priya",
            Name = "Priya Shah",
            Email = "priya@studio.co",
            Initials = "PS",
            IsHost = false,
            Rsvp = RsvpStatus.Going,
            InviteCode = "priya-s",
            DietaryProfile = new DietaryProfile
            {
                Preferences = new() { "Vegetarian" },
                Notes = "Vegetarian stock and no Parmesan."
            }
        };

        var leo = new Guest
        {
            Id = "guest-leo",
            Name = "Leo Martin",
            Email = "leo@studio.co",
            Initials = "LM",
            IsHost = false,
            Rsvp = RsvpStatus.Going,
            InviteCode = "leo-m",
            DietaryProfile = new DietaryProfile()
        };

        ev.Guests = new() { maya, alex, jordan, sam, priya, leo };

        // Seed Pre-orders
        ev.PreOrders = new()
        {
            new GuestPreOrder
            {
                GuestId = maya.Id,
                MenuItemId = risotto.Id,
                Quantity = 1,
                SpecialPrepSummary = "Vegetarian stock; no Parmesan",
                KitchenNote = "Vegetarian stock and no Parmesan please.",
                IsSaved = true
            },
            new GuestPreOrder
            {
                GuestId = alex.Id,
                MenuItemId = salmon.Id,
                Quantity = 1,
                Modifications = new() { "Separate pan & clean utensils", "Separate prep area from shellfish" },
                SpecialPrepSummary = "Separate pan, utensils & prep area",
                KitchenNote = "Please confirm oil and sauces have no shellfish contact. I carry epinephrine.",
                HasKitchenPending = true,
                IsSaved = true
            },
            new GuestPreOrder
            {
                GuestId = jordan.Id,
                MenuItemId = chicken.Id,
                Quantity = 1,
                Modifications = new() { "No added salt", "Sauce on the side" },
                SpecialPrepSummary = "No added salt; sauce on the side",
                KitchenNote = "Please prepare with unsalted stock and provide sauce on side.",
                HasKitchenPending = true,
                IsSaved = true
            },
            new GuestPreOrder
            {
                GuestId = sam.Id,
                MenuItemId = chicken.Id,
                Quantity = 1,
                SpecialPrepSummary = "Standard preparation",
                IsSaved = true
            },
            new GuestPreOrder
            {
                GuestId = priya.Id,
                MenuItemId = risotto.Id,
                Quantity = 1,
                SpecialPrepSummary = "Vegetarian stock; no Parmesan",
                KitchenNote = "Vegetarian stock and no cheese.",
                IsSaved = true
            },
            new GuestPreOrder
            {
                GuestId = leo.Id,
                MenuItemId = salmon.Id,
                Quantity = 1,
                SpecialPrepSummary = "Standard preparation",
                IsSaved = true
            }
        };

        // Seed Kitchen Inquiries
        ev.KitchenInquiries = new()
        {
            new KitchenInquiry
            {
                Id = "inq-alex-shellfish",
                GuestId = alex.Id,
                GuestName = "Alex Rivera",
                CategoryBadge = "ALLERGY · Severe",
                IsSevere = true,
                Title = "Alex · Salmon + shared vegetables",
                QuestionText = "Can both be prepared with a separate pan, clean utensils and a separate prep area away from shellfish? Please confirm oil and sauces too.",
                Status = KitchenConfirmationStatus.AwaitingReply,
                RequestedTimeLabel = "Requested today at 9:30 AM · Awaiting venue reply"
            },
            new KitchenInquiry
            {
                Id = "inq-jordan-sodium",
                GuestId = jordan.Id,
                GuestName = "Jordan Lee",
                CategoryBadge = "PREFERENCE · Low sodium",
                IsSevere = false,
                Title = "Jordan · Herb-roasted chicken",
                QuestionText = "Can the chicken and vegetable share be made without added salt? Is the stock unsalted, and can the sauce be served on the side?",
                Status = KitchenConfirmationStatus.AwaitingReply,
                RequestedTimeLabel = "Requested today at 9:30 AM · Awaiting venue reply"
            }
        };

        CurrentEvent = ev;
    }

    public CompatibilityType EvaluateCompatibility(Guest guest, MenuItem dish, out string badgeText, out string helperText)
    {
        badgeText = "No listed conflict";
        helperText = string.Empty;

        // 1. Direct ingredient conflict for allergies
        var hasShellfishAllergy = guest.DietaryProfile.Allergies.Any(a => a.Allergen.Equals("Shellfish", StringComparison.OrdinalIgnoreCase));
        if (hasShellfishAllergy)
        {
            if (dish.DeclaredAllergens.Any(a => a.Equals("shellfish", StringComparison.OrdinalIgnoreCase)) ||
                dish.Ingredients.Any(i => i.Contains("shrimp", StringComparison.OrdinalIgnoreCase) || i.Contains("shellfish", StringComparison.OrdinalIgnoreCase)))
            {
                badgeText = "Ingredient conflict";
                return CompatibilityType.IngredientConflict;
            }

            // Cross contact risk for kitchen handling shellfish
            badgeText = "Cross-contact?";
            helperText = "Kitchen also handles shellfish";
            return CompatibilityType.CrossContactRisk;
        }

        // 2. Direct ingredient conflict for vegetarian
        var isVegetarian = guest.DietaryProfile.Preferences.Any(p => p.Equals("Vegetarian", StringComparison.OrdinalIgnoreCase));
        if (isVegetarian)
        {
            if (dish.Category == "Main" && (dish.Name.Contains("chicken", StringComparison.OrdinalIgnoreCase) || dish.Name.Contains("salmon", StringComparison.OrdinalIgnoreCase)))
            {
                badgeText = "Ingredient conflict";
                return CompatibilityType.IngredientConflict;
            }
            if (dish.Name.Contains("shrimp", StringComparison.OrdinalIgnoreCase))
            {
                badgeText = "Ingredient conflict";
                return CompatibilityType.IngredientConflict;
            }
            if (dish.Name.Contains("risotto", StringComparison.OrdinalIgnoreCase))
            {
                badgeText = "Modify recipe";
                helperText = "Vegetarian stock & no Parmesan";
                return CompatibilityType.RecipeModification;
            }
        }

        // 3. Low sodium modification
        var isLowSodium = guest.DietaryProfile.Preferences.Any(p => p.Equals("Low sodium", StringComparison.OrdinalIgnoreCase));
        if (isLowSodium)
        {
            badgeText = "Modify recipe";
            helperText = "Unsalted prep / sauce on side";
            return CompatibilityType.RecipeModification;
        }

        badgeText = "No listed conflict";
        return CompatibilityType.NoConflict;
    }

    public EventFinancialSummary CalculateFinances()
    {
        var summary = new EventFinancialSummary
        {
            TaxRate = CurrentEvent.SalesTaxPercent / 100m,
            TipRate = CurrentEvent.TipPercent / 100m
        };

        var guests = CurrentEvent.Guests.Where(g => g.Rsvp == RsvpStatus.Going).ToList();
        var guestCount = Math.Max(1, guests.Count);

        // Shared dishes total (e.g. 2 bowls of Roasted Vegetables = $24.00)
        var sharedDishes = CurrentEvent.Menu.Where(m => m.IsSharedDish).ToList();
        decimal sharedTotal = 0;
        foreach (var sd in sharedDishes)
        {
            sharedTotal += sd.Price * sd.DefaultSharedQuantity;
        }
        summary.SharedBowlTotal = sharedTotal;
        summary.PerPersonSharedAmount = sharedTotal / guestCount; // $4.00 each

        decimal totalMainCost = 0;
        int mainCount = 0;

        foreach (var guest in guests)
        {
            var preOrder = CurrentEvent.PreOrders.FirstOrDefault(p => p.GuestId == guest.Id);
            var dish = preOrder != null ? CurrentEvent.Menu.FirstOrDefault(m => m.Id == preOrder.MenuItemId) : null;

            decimal dishCost = 0;
            string dishName = "Not selected";
            int qty = 1;

            if (dish != null)
            {
                qty = preOrder?.Quantity ?? 1;
                dishCost = dish.Price * qty;
                dishName = dish.Name;
                totalMainCost += dishCost;
                mainCount += qty;
            }

            var foodShare = dishCost + summary.PerPersonSharedAmount;
            var tax = Math.Round(foodShare * summary.TaxRate, 2);
            var tip = Math.Round(foodShare * summary.TipRate, 2);

            summary.Shares.Add(new GuestCostShare
            {
                GuestId = guest.Id,
                GuestName = guest.Name,
                GuestInitials = guest.Initials,
                MainDishName = dishName,
                MainQuantity = qty,
                MainCost = dishCost,
                SharedDishCost = summary.PerPersonSharedAmount,
                TaxAmount = tax,
                TipAmount = tip
            });
        }

        summary.MainCount = mainCount;
        summary.SharedCount = sharedDishes.Sum(s => s.DefaultSharedQuantity);
        summary.FoodSubtotal = totalMainCost + sharedTotal;
        summary.TaxAmount = summary.Shares.Sum(s => s.TaxAmount);
        summary.TipAmount = summary.Shares.Sum(s => s.TipAmount);
        summary.TotalAmount = summary.FoodSubtotal + summary.TaxAmount + summary.TipAmount;

        return summary;
    }

    public void ConfirmKitchenInquiry(string inquiryId, string replyNote = "Confirmed by kitchen")
    {
        var inq = CurrentEvent.KitchenInquiries.FirstOrDefault(i => i.Id == inquiryId);
        if (inq != null)
        {
            inq.Status = KitchenConfirmationStatus.Confirmed;
            inq.ResponseNote = replyNote;

            // Also update pre-order kitchen pending flag
            var preOrder = CurrentEvent.PreOrders.FirstOrDefault(p => p.GuestId == inq.GuestId);
            if (preOrder != null)
            {
                var remaining = CurrentEvent.KitchenInquiries.Where(i => i.GuestId == inq.GuestId && i.Status == KitchenConfirmationStatus.AwaitingReply);
                if (!remaining.Any())
                {
                    preOrder.HasKitchenPending = false;
                }
            }

            NotifyStateChanged();
        }
    }

    public void UpdateGuestPreOrder(string guestId, string dishId, int quantity, List<string> modifications, string note)
    {
        var existing = CurrentEvent.PreOrders.FirstOrDefault(p => p.GuestId == guestId);
        if (existing == null)
        {
            existing = new GuestPreOrder { GuestId = guestId };
            CurrentEvent.PreOrders.Add(existing);
        }

        existing.MenuItemId = dishId;
        existing.Quantity = quantity;
        existing.Modifications = modifications;
        existing.KitchenNote = note;
        existing.IsSaved = true;
        existing.SavedAt = DateTime.Now;

        var dish = CurrentEvent.Menu.FirstOrDefault(m => m.Id == dishId);
        var guest = CurrentEvent.Guests.FirstOrDefault(g => g.Id == guestId);

        if (dish != null && guest != null)
        {
            var compat = EvaluateCompatibility(guest, dish, out _, out var helper);
            if (compat == CompatibilityType.CrossContactRisk || compat == CompatibilityType.RecipeModification)
            {
                existing.HasKitchenPending = true;
            }
            else
            {
                existing.HasKitchenPending = false;
            }
            existing.SpecialPrepSummary = modifications.Count > 0 ? string.Join(", ", modifications) : (helper != string.Empty ? helper : "Standard preparation");
        }

        NotifyStateChanged();
    }

    public void UpdateGuestRsvpAndProfile(string guestId, RsvpStatus rsvp, string name, List<FoodAllergy> allergies, List<string> preferences, string notes)
    {
        var guest = CurrentEvent.Guests.FirstOrDefault(g => g.Id == guestId);
        if (guest != null)
        {
            guest.Rsvp = rsvp;
            if (!string.IsNullOrWhiteSpace(name))
            {
                guest.Name = name;
                guest.Initials = Guest.GenerateInitials(name);
            }
            guest.DietaryProfile.Allergies = allergies;
            guest.DietaryProfile.Preferences = preferences;
            guest.DietaryProfile.Notes = notes;

            NotifyStateChanged();
        }
    }

    public void UpdateRates(decimal taxPercent, decimal tipPercent)
    {
        CurrentEvent.SalesTaxPercent = Math.Clamp(taxPercent, 0, 50);
        CurrentEvent.TipPercent = Math.Clamp(tipPercent, 0, 100);
        NotifyStateChanged();
    }

    public void UpdateGuestRsvp(string guestId, RsvpStatus rsvp)
    {
        var guest = CurrentEvent.Guests.FirstOrDefault(g => g.Id == guestId);
        if (guest != null)
        {
            guest.Rsvp = rsvp;
            NotifyStateChanged();
        }
    }

    public void AddGuest(string name, string email, List<string> allergens, List<string> preferences, string notes = "")
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        var id = "guest-" + Guid.NewGuid().ToString("N")[..8];
        var guest = new Guest
        {
            Id = id,
            Name = name.Trim(),
            Email = string.IsNullOrWhiteSpace(email) ? $"{name.ToLower().Replace(" ", ".")}@example.com" : email.Trim(),
            Initials = Guest.GenerateInitials(name),
            Rsvp = RsvpStatus.Going,
            DietaryProfile = new DietaryProfile
            {
                Allergies = allergens.Select(a => new FoodAllergy { Allergen = a, Severity = AllergySeverity.Moderate }).ToList(),
                Preferences = preferences,
                Notes = notes
            }
        };

        CurrentEvent.Guests.Add(guest);
        CurrentEvent.TableInfo = $"Garden table · {CurrentEvent.Guests.Count} guests";

        // Assign default dish
        var defaultDish = CurrentEvent.Menu.FirstOrDefault(m => !m.IsSharedDish) ?? CurrentEvent.Menu.First();
        CurrentEvent.PreOrders.Add(new GuestPreOrder
        {
            GuestId = id,
            MenuItemId = defaultDish.Id,
            Quantity = 1,
            IsSaved = true,
            SavedAt = DateTime.Now,
            SpecialPrepSummary = "Standard preparation"
        });

        NotifyStateChanged();
    }

    public void RemoveGuest(string guestId)
    {
        var guest = CurrentEvent.Guests.FirstOrDefault(g => g.Id == guestId);
        if (guest != null && !guest.IsHost)
        {
            CurrentEvent.Guests.Remove(guest);
            CurrentEvent.PreOrders.RemoveAll(p => p.GuestId == guestId);
            CurrentEvent.KitchenInquiries.RemoveAll(k => k.GuestId == guestId);
            CurrentEvent.TableInfo = $"Garden table · {CurrentEvent.Guests.Count} guests";
            NotifyStateChanged();
        }
    }
}


