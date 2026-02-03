using ChalanaChithram.CastService.Api.Entities;

namespace ChalanaChithram.CastService.Api.Repositories.Interfaces;
public interface ICastRepository
{
    Task<List<MovieCredit>> GetByMovieIdAsync(int movieId);
    Task<MovieCredit?> GetByCreditIdAsync(int creditId);
}
