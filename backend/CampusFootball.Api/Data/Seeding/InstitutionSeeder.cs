namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class InstitutionSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 6;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Institution>().Any()) return; // guard against duplicate inserts

        Institution AAU = new() { Name = "AAU", Parent = null };

        Institution FacultyOfEngAndNatSci = new() { Name = "Faculty of Engineering and Natural Sciences", Parent = AAU };
        Institution DeptOfConCityAndEnv = new() { Name = "Deparment of Construction City and Environment", Parent = FacultyOfEngAndNatSci };

        Institution FacultyOfIT = new() { Name = "Technical Faculty of IT and Design", Parent = AAU };
        Institution DeptOfCompSci = new() { Name = "Department of Computer Science", Parent = FacultyOfIT };

        Institution FacultyOfMed = new() { Name = "Faculty of Medicine", Parent = AAU };
        Institution DeptOfHealthSciAndTech = new() { Name = "Department of Health Science and Technology", Parent = FacultyOfMed };

        Institution[] institutions = [
            AAU, FacultyOfIT, DeptOfCompSci, FacultyOfEngAndNatSci, DeptOfConCityAndEnv, FacultyOfMed, DeptOfHealthSciAndTech
        ];

        context.Set<Institution>().AddRange(institutions);
        context.SaveChanges();
    }
}