using CarMarketplace.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options => options.LoginPath = $"/Application/SignIn");
builder.Services.AddAuthorization();

builder.Services.AddDbContextPool<MarketplaceContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("MarketplaceDBConnectionString"))
    );

builder.Services.AddScoped<IRepository, MarketplaceRepository>();
builder.Services.AddSingleton<IHashComputer, Hasher>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();