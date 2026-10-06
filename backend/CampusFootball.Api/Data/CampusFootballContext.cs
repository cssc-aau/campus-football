using CampusFootball.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CampusFootball.Api.Data;

public class CampusFootballContext : DbContext
{
    //Required public constructor st. configuration from AddDbContext is passed to the base constructor for DbContext. 
    public CampusFootballContext(DbContextOptions<CampusFootballContext> options)
      : base(options) { }
    
    //Seasons & Competitions
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<CompetitionSeason> CompetitionSeasons { get; set; } //Explicit DbSet needed or queried via navigational properties?

    //Matches
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchEvent> MatchEvents => Set<MatchEvent>();
    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<Card> Cards => Set<Card>();

    public DbSet<Venue> Venues { get; set; }
    
    //Teams & Roles. Person explicit DbSet?
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamRole> TeamRoles => Set<TeamRole>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Coach> Coaches => Set<Coach>();
    public DbSet<Leader> Leaders => Set<Leader>();

    public DbSet<Institution> Institutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Discovers & applies all explicit database-model mapping configurations, which implement IEntityTypeConfiguration<Model>.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CampusFootballContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //Singular table names from model class, instead of plural from DbSet variables 
        configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
    }
}