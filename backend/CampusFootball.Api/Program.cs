using CampusFootball.Api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using CampusFootball.Api.Data.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Register the app's services in the DI Container
builder.Services.AddOpenApi();

string? connectionString = builder.Configuration.GetConnectionString("Database")
        ?? throw new InvalidOperationException("Connection string 'Database' not found.");

builder.Services.AddDbContext<CampusFootballContext>(optionsBuilder => 
{
    optionsBuilder.UseNpgsql(connectionString);

    if(builder.Environment.IsDevelopment())
    {
        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            IEnumerable<ISeeder> seeders = typeof(CampusFootballContext)
                .Assembly // Gets all classes from the assembly CampusFootballContext gets compiled into (all classes)
                .GetTypes()
                .Where(type => typeof(ISeeder).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract) // Ensures only entities compatible with ISeeder are included (excluding ISeeder itself)
                .Select(type => (ISeeder)Activator.CreateInstance(type)!) // Creates instances of said classes
                .OrderBy(seeder => seeder.SeedingOrder); // Ensures seeding happens in the correct order in respect to FK linking

            foreach (ISeeder seeder in seeders)
            {
                seeder.Seed((CampusFootballContext)context);
            }
        });
    }
});

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
    app.MapScalarApiReference("/api");
}

// Configure the HTTP request pipeline, middleware
app.UseHttpsRedirection();

// Map endpoints
app.MapGet("/", () => "Hello World!");

app.Run();