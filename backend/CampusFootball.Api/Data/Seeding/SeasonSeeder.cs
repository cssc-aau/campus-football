namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class SeasonSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 3;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Season>().Any()) return; // guard against duplicate inserts

        Season[] seasons = [
            new() { StartYear = 2025 },
            new() { StartYear = 2026 },
            new() { StartYear = 2027 }
        ];

        context.Set<Season>().AddRange(seasons);
        context.SaveChanges();
    }
}