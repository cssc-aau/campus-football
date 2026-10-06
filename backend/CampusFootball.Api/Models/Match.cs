using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusFootball.Api.Models;

public class Match
{
    public int Id { get; init; }

    public int HomeTeamId { get; init; }
    public Team HomeTeam { get; init; }

    public int AwayTeamId{ get; init; }
    public Team AwayTeam { get; init; }

    /* Identifies competition instance a match belongs to. Used to configure Composite Foreign Key. 
     "Friendlies" considered competitions for uniform treatment */
    public int CompetitionId { get; init; }
    public int SeasonId { get; init; }
    public CompetitionSeason CompetitionSeason { get; init; }

    public DateTime KickOff{ get; set; }

    //Modelling, exact pitch?
    public int VenueId{ get; set; }
    public Venue Venue { get; set; }

    //To do: research ordering, possibly solved by using List?
    public ICollection<MatchEvent> Events { get; } = [];
} 

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasOne(match => match.CompetitionSeason)
            .WithMany(compSeason => compSeason.Matches)
            .HasForeignKey(match => new { match.CompetitionId, match.SeasonId });
    }
}