namespace CampusFootball.Api.Models;

public class Institution
{
    public int Id { get; init; }
    public string Name { get; set; }

    public int? ParentId { get; set; }
    public Institution? Parent { get; set; }
}