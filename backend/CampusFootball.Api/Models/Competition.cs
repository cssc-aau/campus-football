namespace CampusFootball.Api.Models
{
    public class Competition
    {
        public int Id { get; init; }
        public string Name { get; set;}
        
        //The different "instances" of the competition. Champions League: 25/26, 26/27 ...
        public ICollection<CompetitionSeason> Seasons { get; } = [];
    }
}