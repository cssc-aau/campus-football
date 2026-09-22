namespace CampusFootball.Api.Models
{
    public class Season
    {
        public int Id { get; init; }

        //EndYear derived
        public int StartYear { get; init; }

        //Mirrored in Competition: Many-to-Many, EF Core maps to a joining table
         public ICollection<CompetitionSeason> CompetitionSeasons { get; } = [];
    }
}