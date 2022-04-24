using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IDatabaseData, SqlData>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<ISqliteDataAccess, SqliteDataAccess>();




string dbChoice = builder.Configuration.GetValue<string>("DatabaseChoice").ToLower();

if (dbChoice == "sql")
{
    builder.Services.AddTransient<IDatabaseData, SqlData>();
}
else if (dbChoice == "sqlite")
{
    builder.Services.AddTransient<IDatabaseData, SqliteData>();
}
else
{
    // Fallback / Default Value
    builder.Services.AddTransient<IDatabaseData, SqlData>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
