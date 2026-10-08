namespace CampusFootball.Api.Models;

public class Team
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Abbreviation  { get; set; }

    // CS & SW, !IT - Department of CS cannot surfice. Depends on Study Programme handling
    // Many to many relation, joining table, needed?
    public int InstitutionId { get; init; }
    public Institution Institution { get; init; }

    public ICollection<TeamRole> MemberRoles { get; } = []; 
}