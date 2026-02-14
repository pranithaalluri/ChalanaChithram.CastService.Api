using ChalanaChithram.CastService.Api.Dtos;
using ChalanaChithram.CastService.Api.Entities;
using ChalanaChithram.CastService.Api.Repositories.Interfaces;
using ChalanaChithram.CastService.Api.Services.Interfaces;

namespace ChalanaChithram.CastService.Api.Services;

public class CastService(ICastRepository castRepository) : ICastService
{
    private readonly ICastRepository castRepository = castRepository;

    public async Task<List<MovieCreditDto>> GetCastByMovieIdAsync(int movieId)
    {

        List<MovieCredit> credits =
            await castRepository.GetByMovieIdAsync(movieId);

        return credits.Select(MapToDto).ToList();


    }

    public async Task<MovieCreditDto?> GetCreditByIdAsync(int creditId)
    {

        MovieCredit? credit =
            await castRepository.GetByCreditIdAsync(creditId);

        if (credit == null)
        {
            return null;
        }

        return MapToDto(credit);

    }

    private static MovieCreditDto MapToDto(MovieCredit x)
    {
        return new MovieCreditDto
        {
            Id = x.Id,
            MovieId = x.MovieId,
            PersonId = x.PersonId,
            Role = x.Role,
            CharacterName = x.CharacterName,
            Order = x.Order,
            Person = x.Person == null ? null : new PersonDto
            {
                Id = x.Person.Id,
                Name = x.Person.Name,
                ProfileImage = x.Person.ProfileImage,
                InstagramUrl = x.Person.InstagramUrl,
                TwitterUrl = x.Person.TwitterUrl,
                FacebookUrl = x.Person.FacebookUrl,
                YoutubeUrl = x.Person.YoutubeUrl
            }
        };
    }
}
