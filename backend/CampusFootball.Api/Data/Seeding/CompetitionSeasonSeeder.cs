namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class CompetitionSeasonSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 4;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<CompetitionSeason>().Any()) return; // guard against duplicate inserts

        Competition[] competitions = context.Set<Competition>().ToArray();
        Season[] seasons = context.Set<Season>().ToArray();

        CompetitionSeason[] competitionSeasons = [
            new() { Competition = competitions[0], Season = seasons[0] },
            new() { Competition = competitions[1], Season = seasons[0] },
            new() { Competition = competitions[0], Season = seasons[1] },
            new() { Competition = competitions[1], Season = seasons[1] }
        ];

        context.Set<CompetitionSeason>().AddRange(competitionSeasons);
        context.SaveChanges();
    }
}