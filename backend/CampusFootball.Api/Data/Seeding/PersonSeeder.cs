namespace CampusFootball.Api.Data.Seeding;
using CampusFootball.Api.Models;

public class PersonSeeder : ISeeder
{
    public int SeedingOrder { get; init; } = 5;
    public void Seed(CampusFootballContext context)
    {
        if (context.Set<Person>().Any()) return; // guard against duplicate inserts

        Person[] persons = [
            new() { FirstName = "Mads", LastName = "Hermansen" },
            new() { FirstName = "Filip", LastName = "Jørgensen" },
            new() { FirstName = "Andreas", LastName = "Jungdal" },
            new() { FirstName = "Joakim", LastName = "Mæhle" },
            new() { FirstName = "Joachim", LastName = "Andersen" },
            new() { FirstName = "Oliver", LastName = "Provstgaard" },
            new() { FirstName = "Rasmus", LastName = "Nicolaisen" },
            new() { FirstName = "Lucas", LastName = "Høgsberg" },
            new() { FirstName = "Victor", LastName = "Nelsson" },
            new() { FirstName = "Rasmus", LastName = "Kristensen" },
            new() { FirstName = "Alexander", LastName = "Bah" },
            new() { FirstName = "Anton", LastName = "Gaaei" },
            new() { FirstName = "Patrick", LastName = "Dorgu" },
            new() { FirstName = "Mathias", LastName = "Jensen" },
            new() { FirstName = "Thomas", LastName = "Jørgensen" },
            new() { FirstName = "Victor", LastName = "Froholdt" },
            new() { FirstName = "Nikolas", LastName = "Nartey" },
            new() { FirstName = "Jesper", LastName = "Lindstrøm" },
            new() { FirstName = "Mohamed", LastName = "Daramy" },
            new() { FirstName = "Mads", LastName = "Bidstrup" },
            new() { FirstName = "Albert", LastName = "Grønbæk" },
            new() { FirstName = "Morten", LastName = "Hjulmand" },
            new() { FirstName = "Pierre-Emile", LastName = "Højbjerg" },
            new() { FirstName = "Gustav", LastName = "Isaksen" },
            new() { FirstName = "Rasmus", LastName = "Højlund" },
            new() { FirstName = "William", LastName = "Osula" },
            new() { FirstName = "Andreas", LastName = "Skov Olsen" },
            new() { FirstName = "Mikkel", LastName = "Damsgaard" },
            new() { FirstName = "Mathias", LastName = "Kvistgaarden" },
            new() { FirstName = "Adam", LastName = "Daghim" },
            new() { FirstName = "Kasper", LastName = "Høgh" },
            new() { FirstName = "Kasper", LastName = "Schmeichel" },
            new() { FirstName = "Frederik", LastName = "Rønnow" },
            new() { FirstName = "Andreas", LastName = "Christensen" },
            new() { FirstName = "Jannik", LastName = "Vestergaard" },
            new() { FirstName = "Christian", LastName = "Eriksen" },
            new() { FirstName = "Christian", LastName = "Nørgaard" },
            new() { FirstName = "Matt", LastName = "O'Riley" },
            new() { FirstName = "Victor", LastName = "Jensen" },
            new() { FirstName = "Philip", LastName = "Billing" },
            new() { FirstName = "Anders", LastName = "Dreyer" },
            new() { FirstName = "Morten", LastName = "Frendrup" },
            new() { FirstName = "Kasper", LastName = "Dolberg" },
            new() { FirstName = "Jonas", LastName = "Wind" },
            new() { FirstName = "Yussuf", LastName = "Poulsen" },
            new() { FirstName = "Mika", LastName = "Biereth" },
            new() { FirstName = "Jacob", LastName = "Bruun Larsen" },
            new() { FirstName = "Jens", LastName = "Stryger Larsen" },
            new() { FirstName = "Simon", LastName = "Kjær" },
            new() { FirstName = "Daniel", LastName = "Wass" },
            new() { FirstName = "Thomas", LastName = "Delaney" },
            new() { FirstName = "Martin", LastName = "Braithwaite" },
            new() { FirstName = "Nicolai", LastName = "Jørgensen" },
            new() { FirstName = "Pione", LastName = "Sisto" },
            new() { FirstName = "Robert", LastName = "Skov" },
            new() { FirstName = "Lasse", LastName = "Schöne" },
            new() { FirstName = "William", LastName = "Kvist" },
            new() { FirstName = "Michael", LastName = "Krohn-Dehli" },
            new() { FirstName = "Nicklas", LastName = "Bendtner" },
            new() { FirstName = "Dennis", LastName = "Rommedahl" },
            new() { FirstName = "Jon", LastName = "Dahl Tomasson" },
            new() { FirstName = "Peter", LastName = "Schmeichel" },
            new() { FirstName = "Brian", LastName = "Laudrup" },
        ];

        context.Set<Person>().AddRange(persons);
        context.SaveChanges();
    }
}