using ChalanaChithram.CastService.Api.Dtos;
using ChalanaChithram.CastService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChalanaChithram.CastService.Api.Controllers;

[ApiController]
[Route("api/cast")]
public class CastController(ICastService castService) : ControllerBase
{
    private readonly ICastService castService = castService;

    /// <summary>
    /// Get all cast members for a movie
    /// </summary>
    [HttpGet("movie/{movieId:int}")]
    public async Task<IActionResult> GetCastByMovieId(int movieId)
    {
        List<MovieCreditDto> cast =
            await castService.GetCastByMovieIdAsync(movieId);

        return Ok(cast);
    }

    /// <summary>
    /// Get a single cast credit by credit id
    /// </summary>
    [HttpGet("credit/{creditId:int}")]
    public async Task<IActionResult> GetCreditById(int creditId)
    {
        MovieCreditDto? credit =
            await castService.GetCreditByIdAsync(creditId);

        if (credit == null)
        {
            return NotFound();
        }

        return Ok(credit);
    }
}
