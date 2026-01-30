using ChalanaChithram.CastService.Api.Data;
using ChalanaChithram.CastService.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChalanaChithram.CastService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CastController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext dbContext = dbContext;

    [HttpGet("by-movie/{movieId:int}")]
    public async Task<IActionResult> GetCastByMovieId(int movieId)
    {
        List<MovieCreditDto> credits = await dbContext.MovieCredits
            .AsNoTracking()
            .Where(x => x.MovieId == movieId)
            .Include(x => x.Person)
            .OrderBy(x => x.Order)
            .Select(x => new MovieCreditDto
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
                    ProfileImageUrl = x.Person.ProfileImageUrl,
                    InstagramUrl = x.Person.InstagramUrl,
                    TwitterUrl = x.Person.TwitterUrl,
                    FacebookUrl = x.Person.FacebookUrl,
                    YoutubeUrl = x.Person.YoutubeUrl
                }
            })
            .ToListAsync();

        return Ok(credits);
    }


    [HttpGet("credit/{creditId:int}")]
    public async Task<IActionResult> GetCreditById(int creditId)
    {
        MovieCreditDto? credit = await dbContext.MovieCredits
            .AsNoTracking()
            .Include(x => x.Person)
            .Where(x => x.Id == creditId)
            .Select(x => new MovieCreditDto
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
                    ProfileImageUrl = x.Person.ProfileImageUrl,
                    InstagramUrl = x.Person.InstagramUrl,
                    TwitterUrl = x.Person.TwitterUrl,
                    FacebookUrl = x.Person.FacebookUrl,
                    YoutubeUrl = x.Person.YoutubeUrl
                }
            })
            .FirstOrDefaultAsync();

        if (credit == null)
        {
            return NotFound(new { message = "Movie credit not found." });
        }

        return Ok(credit);
    }
}
