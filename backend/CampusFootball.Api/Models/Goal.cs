namespace CampusFootball.Api.Models;

public class Goal : MatchEvent
{
    //Goal may not have assister
    public int? AssisterId { get; set; }
    public TeamRole? Assister { get; set; }        
}