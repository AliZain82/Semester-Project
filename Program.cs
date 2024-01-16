using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add your services
builder.Services.AddTransient<UserService>()
    .AddTransient<CategoryService>()
    .AddTransient<BlogPostService>();

// Add authentication services
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<BlogAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, BlogAuthenticationStateProvider>();

var BlogConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(Options => Options.UseSqlServer(BlogConnectionString));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
