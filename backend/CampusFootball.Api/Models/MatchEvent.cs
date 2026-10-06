using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusFootball.Api.Models;

public abstract class MatchEvent 
{
    public int Id { get; init; }

    //Required since Player is optional, must know what team the event belongs to
    public int TeamId { get; init; } 
    public Team Team { get; init; }

    public int? Minute { get; set; } 
}

public class MatchEventConfiguration : IEntityTypeConfiguration<MatchEvent>
{
    public void Configure(EntityTypeBuilder<MatchEvent> builder)
    {
        //TPC (Table-per-Concrete-type). All concrete specializations mapped to individual tables with columns for inherited properties
        builder.UseTpcMappingStrategy();
    }
}