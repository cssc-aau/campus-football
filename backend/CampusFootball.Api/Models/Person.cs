namespace CampusFootball.Api.Models;

public class Person
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<TeamRole> TeamRoles { get; } = [];
}