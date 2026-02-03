using ChalanaChithram.CastService.Api.Data;
using ChalanaChithram.CastService.Api.Entities;
using ChalanaChithram.CastService.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChalanaChithram.CastService.Api.Repositories;
public class CastRepository(AppDbContext dbContext) : ICastRepository
{
    private readonly AppDbContext dbContext = dbContext;

    public async Task<List<MovieCredit>> GetByMovieIdAsync(int movieId)
    {
        return await dbContext.MovieCredits
            .AsNoTracking()
            .Include(x => x.Person)
            .Where(x => x.MovieId == movieId)
            .OrderBy(x => x.Order)
            .ToListAsync();
    }

    public async Task<MovieCredit?> GetByCreditIdAsync(int creditId)
    {
        return await dbContext.MovieCredits
            .AsNoTracking()
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == creditId);
    }
}
