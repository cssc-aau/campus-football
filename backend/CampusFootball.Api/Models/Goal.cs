namespace CampusFootball.Api.Models;

public class Goal : MatchEvent
{
    //Optional. Don't force teams to log / opposing team player may be unknown
    public int? ScorerId { get; set; }
    public Player? Scorer { get; set; }

    //Goal may not have assister
    public int? AssisterId { get; set; }
    public Player? Assister { get; set; }        
}