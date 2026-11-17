namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class CompetitionSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 2;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Competition>().Any()) return; // guard against duplicate inserts

        Competition[] competitions = [
            new() { Name = "AAU Liga" },
            new() { Name = "Studiestart AAU Cup" }
        ];

        context.Set<Competition>().AddRange(competitions);
        context.SaveChanges();
    }
}