namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class InstitutionSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 4;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Institution>().Any()) return; // guard against duplicate inserts

        Institution AAU = new() { Name = "AAU", Parent = null };
        Institution FacultyOfIT = new() { Name = "Faculty of IT", Parent = AAU };
        Institution DeptOfCompSci = new() { Name = "Department of Computer Science", Parent = FacultyOfIT};
        Institution Software = new() { Name = "Software", Parent = DeptOfCompSci };
        Institution CompSci = new() { Name = "Computer Science", Parent = DeptOfCompSci };

        Institution[] institutions = [
            AAU, FacultyOfIT, DeptOfCompSci, Software, CompSci
        ];

        context.Set<Institution>().AddRange(institutions);
        context.SaveChanges();
    }
}