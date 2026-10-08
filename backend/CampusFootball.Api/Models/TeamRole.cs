using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusFootball.Api.Models;

public abstract class TeamRole
{
    public int Id { get; init; }
    public int PersonId { get; init; }
    public Person Person { get; init; }

    public int TeamId { get; init; }
    public virtual Team Team { get; init; }

    public Season FromSeason { get; init; }
    public Season? ToSeason { get; set; }
}
public class Player : TeamRole { }
public class Coach : TeamRole { }
public class Leader : TeamRole { }

public class TeamRoleConfiguration : IEntityTypeConfiguration<TeamRole>
{
    public void Configure(EntityTypeBuilder<TeamRole> builder)
    {
        // TPH (Table-per-Hierarchy) mapping strategy for static typing - until specializations introduce attributes
        builder.UseTphMappingStrategy()
          .HasDiscriminator<string>("RoleType");
    }
}