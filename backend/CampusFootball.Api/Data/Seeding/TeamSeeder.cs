namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class TeamSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 7;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Team>().Any()) return; // guard against duplicate inserts

        Institution CompSci = context.Set<Institution>().First(org => org.Name == "Department of Computer Science");
        Institution BUILD = context.Set<Institution>().First(org => org.Name == "Deparment of Construction City and Environment");
        Institution MedIS = context.Set<Institution>().First(org => org.Name == "Department of Health Science and Technology");

        Team[] teams = [
            new() { Name = "Computer Science Sports Club", Abbreviation = "CSSC", InstitutionId = CompSci.Id },
            new() { Name = "BuildBold", Abbreviation = "BB", InstitutionId = BUILD.Id },
            new() { Name = "Alpha Dragonflies", Abbreviation = "ADF", InstitutionId = MedIS.Id }
        ];

        context.Set<Team>().AddRange(teams);
        context.SaveChanges();
    }
}