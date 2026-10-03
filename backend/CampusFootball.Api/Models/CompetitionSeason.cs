using Microsoft.EntityFrameworkCore;

namespace CampusFootball.Api.Models;

[PrimaryKey(nameof(CompetitionId), nameof(SeasonId))]
public class CompetitionSeason
{
    public int CompetitionId { get; init; }
    public Competition Competition;

    public int SeasonId { get; init; }
    public Season Season;

    public ICollection<Match> Matches { get; } = [];
}