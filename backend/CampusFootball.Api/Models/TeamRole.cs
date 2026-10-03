namespace CampusFootball.Api.Models;

public class TeamRole
{
    public int Id { get; init; }
    public int PersonId { get; init; }
    public Person Person { get; init; }

    public int TeamId { get; init; }
    public virtual Team Team { get; init; }

    //Decision: Specialize instead if additional attributes are needed dependant on below value.
    public RoleType Type { get; init; }

    public Season FromSeason { get; init; }
    public Season? ToSeason { get; set; }
}

public enum RoleType
{
    Leader, Coach, AssistantCoach, Player
}
