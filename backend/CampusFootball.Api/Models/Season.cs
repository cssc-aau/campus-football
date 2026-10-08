namespace CampusFootball.Api.Models;

public class Season
{
    public int Id { get; init; }

    //EndYear derived
    public int StartYear { get; init; }

    //The competion instances within the season. 26/27 - Champions League, Europa League
    public ICollection<CompetitionSeason> Competitions { get; } = [];
}