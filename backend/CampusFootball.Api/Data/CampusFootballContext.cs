using CampusFootball.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CampusFootball.Api.Data;

public class CampusFootballContext : DbContext
{
    //Required public constructor st. configuration from AddDbContext is passed to the base constructor for DbContext. 
    public CampusFootballContext(DbContextOptions<CampusFootballContext> options)
      : base(options) { }
    
    
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<CompetitionSeason> CompetitionSeasons { get; set; }

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