using System;
using System.Linq;
using System.Threading.Tasks;
using ChalanaChithram.CastService.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ChalanaChithram.CastService.Api.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        IServiceScope scope = serviceProvider.CreateScope();
        IServiceProvider scopedServices = scope.ServiceProvider;

        AppDbContext dbContext = scopedServices.GetRequiredService<AppDbContext>();
        ILoggerFactory loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();
        ILogger logger = loggerFactory.CreateLogger("CastService.DatabaseSeeder");

        try
        {
            await dbContext.Database.MigrateAsync();

            if (!dbContext.People.Any())
            {
                dbContext.People.AddRange(CastSeedData.GetPeople());
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.MovieCredits.Any())
            {
                dbContext.MovieCredits.AddRange(CastSeedData.GetMovieCredits());
                await dbContext.SaveChangesAsync();
            }

            logger.LogInformation("CastService DB seeded successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CastService DB seeding failed.");
            throw;
        }
        finally
        {
            scope.Dispose();
        }
    }
}
