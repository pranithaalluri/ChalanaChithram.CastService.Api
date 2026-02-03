using ChalanaChithram.CastService.Api.Dtos;

namespace ChalanaChithram.CastService.Api.Services.Interfaces;

public interface ICastService
{
    Task<List<MovieCreditDto>> GetCastByMovieIdAsync(int movieId);
    Task<MovieCreditDto?> GetCreditByIdAsync(int creditId);
}