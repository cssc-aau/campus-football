namespace CampusFootball.Api.Models;

public class Card : MatchEvent
{
    //Optional. Don't force teams to log / opposing team person may be unknown
    public int? ReceiverId { get; set; }
    // Coach/Leader can receive cards
    public TeamRole? Receiver { get; set; }
    public CardType Type { get; set; }
}

public enum CardType
{
    YellowCard, RedCard
}