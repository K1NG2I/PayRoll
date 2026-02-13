using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register MVC and Razor Pages (keep existing registrations as needed)
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

// If you use auth, keep these (order matters)
app.UseAuthentication();
app.UseAuthorization();

// Redirect root to the new Razor Pages landing
app.MapGet("/", context =>
{
    context.Response.Redirect("/Landing");
    return Task.CompletedTask;
});

// Make controller default route explicit (avoids falling back to Login controller)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Dashboard}/{id?}"
);

// Map Razor Pages (Landing.cshtml)
app.MapRazorPages();

app.Run();