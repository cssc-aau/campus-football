namespace CampusFootball.Api.Models
{
    public class Competition
    {
        public int Id { get; init; }
        public string Name { get; set;}
        
        //Mirrored in Season: Many-to-Many, EF Core maps to a joining table
         public ICollection<CompetitionSeason> CompetitionSeasons { get; } = [];
    }
}