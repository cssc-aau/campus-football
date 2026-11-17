namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class VenueSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 1;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Venue>().Any()) return; // guard against duplicate inserts (can probably be removed by courtesy of having no volumes)

        Venue[] venues = [
            new() { Name = "Domen", Address = "Thomas Manns Vej 20"},
            new() { Name = "Parken", Address = "Per Henrik Lings Allé 2"},
        ];

        context.Set<Venue>().AddRange(venues);
        context.SaveChanges();
    }
}