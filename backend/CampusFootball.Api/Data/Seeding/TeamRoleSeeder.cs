namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class TeamRoleSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 8;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<TeamRole>().Any()) return; // guard against duplicate inserts

        Person[] persons = context.Set<Person>().ToArray();
        Team[] teams = context.Set<Team>().ToArray();
        Season[] seasons = context.Set<Season>().ToArray();

        Player[] players = [
            new() { PersonId = persons[0].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = null },
            new() { PersonId = persons[1].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = null },
            new() { PersonId = persons[2].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = null },
            new() { PersonId = persons[3].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = null },
            new() { PersonId = persons[4].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = seasons[1] },
            new() { PersonId = persons[5].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = seasons[2] },
            new() { PersonId = persons[6].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = seasons[2] }
        ];
        Coach[] coaches = [
            new() { PersonId = persons[7].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = seasons[1] },
            new() { PersonId = persons[8].Id, TeamId = teams[0].Id, FromSeason = seasons[1], ToSeason = null }
        ];
        Leader[] leaders = [
            new() { PersonId = persons[9].Id, TeamId = teams[0].Id, FromSeason = seasons[0], ToSeason = null },
        ];

        context.Set<TeamRole>().AddRange(players);
        context.Set<TeamRole>().AddRange(coaches);
        context.Set<TeamRole>().AddRange(leaders);
        context.SaveChanges();
    }
}