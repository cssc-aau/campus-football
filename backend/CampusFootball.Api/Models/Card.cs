namespace CampusFootball.Api.Models;

public class Card : MatchEvent
{
    public CardType Type { get; set; }
}

public enum CardType
{
    YellowCard, RedCard
}