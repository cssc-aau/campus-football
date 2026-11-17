namespace CampusFootball.Api.Data.Seeding;

public interface ISeeder
{
    public int SeedingOrder { get; init; }

    public abstract void Seed(CampusFootballContext context);

}