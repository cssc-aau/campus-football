using CampusFootball.Api.Data;
using Microsoft.EntityFrameworkCore;

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
        await dbContext.Database.MigrateAsync();
    }

    // Map Api documentation endpoints
    app.MapOpenApi();
}

// Configure the HTTP request pipeline, middleware
app.UseHttpsRedirection();

// Map endpoints
app.MapGet("/", () => "Hello World!");

app.Run();