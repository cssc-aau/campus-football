using CampusFootball.Api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register the app's services in the DI Container
builder.Services.AddOpenApi();

string? connectionString = builder.Configuration.GetConnectionString("Database")
        ?? throw new InvalidOperationException("Connection string 'Database' not found.");

builder.Services.AddDbContext<CampusFootballContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(connectionString)
);

var app = builder.Build();

// Configure development-only behavior
if (app.Environment.IsDevelopment())
{
    // Apply pending database migrations on startup to keep the development database's schema up to date
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<CampusFootballContext>();
        var pendingMigrations = dbContext.Database.GetPendingMigrations(); // find unapplied migrations
        if (pendingMigrations.Any()) // if any:
        {
            dbContext.Database.Migrate(); // apply them
        }
    }

    // Map Api documentation endpoints
    app.MapOpenApi();
    app.MapScalarApiReference("/api");
}

// Configure the HTTP request pipeline, middleware
app.UseHttpsRedirection();

// Map endpoints
app.MapGet("/", () => "Hello World!");

app.Run();