using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        //Store CardType enum as string, rather than the backing integer. Fragility if addition, e.g. SecondYellow
        builder.Property(card => card.Type)
            .HasConversion<string>();
    }
}