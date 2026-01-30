using ChalanaChithram.CastService.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChalanaChithram.CastService.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();

    public DbSet<MovieCredit> MovieCredits => Set<MovieCredit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
