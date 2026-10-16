using CampusFootball.Api.Data;
using CampusFootball.Api.Models;

namespace CampusFootball.Api.Matches;

//Primary constructor with DbContex injected
internal sealed class MatchService(CampusFootballContext db)
{
    internal async Task<Match?> GetMatch(int id) => await db.Matches.FindAsync(id);    
}
