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
            new() { CompetitionId = competitions[0].Id, SeasonId = seasons[0].Id },
            new() { CompetitionId = competitions[1].Id, SeasonId = seasons[0].Id },
            new() { CompetitionId = competitions[0].Id, SeasonId = seasons[1].Id },
            new() { CompetitionId = competitions[1].Id, SeasonId = seasons[1].Id }
        ];

        context.Set<CompetitionSeason>().AddRange(competitionSeasons);
        context.SaveChanges();
    }
}