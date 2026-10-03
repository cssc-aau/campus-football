namespace CampusFootball.Api.Models;

public abstract class MatchEvent 
{
    public int Id { get; init; }

    //Required since Player is optional, must know what team the event belongs to
    public int TeamId { get; init; } 
    public Team Team { get; init; }

    //Optional. Don't force teams to log / opposing team player may be unknown
    public int? PlayerId { get; set; }
    public TeamRole? Player { get; set; }

    public int? Minute { get; set; } 
}
