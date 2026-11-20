using Sprint.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<Sprint.Services.DiningCoordinatorService>();

// Configure and register Supabase Client (Slide 47)
var supabaseUrl = builder.Configuration["Supabase:Url"] ?? "https://rxgocwzyzviojcmpkcid.supabase.co";
var supabaseKey = builder.Configuration["Supabase:Key"] ?? "sb_publishable_nsRGap2vFcvN0ccRO_gIEg_zuByhwB8";
var supabaseOptions = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = false
};
var supabase = new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions);
try
{
    await supabase.InitializeAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"[Supabase] Note: Initialization deferred or offline: {ex.Message}");
}
builder.Services.AddSingleton(supabase);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
