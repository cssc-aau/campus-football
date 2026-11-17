namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class MatchSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 9;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Match>().Any()) return; // guard against duplicate inserts

        CompetitionSeason[] competitionSeasons = context.Set<CompetitionSeason>().ToArray();
        Team[] teams = context.Set<Team>().ToArray();
        Venue[] venues = context.Set<Venue>().ToArray();

        Match[] matches = [
            new() { HomeTeamId = teams[0].Id, AwayTeamId = teams[1].Id, CompetitionId = competitionSeasons[0].CompetitionId, SeasonId = competitionSeasons[0].SeasonId, KickOff = new DateTime(2026, 1, 1), VenueId = venues[0].Id },
        ];

        context.Set<Match>().AddRange(matches);
        context.SaveChanges();
    }
}