using ChalanaChithram.CastService.Api.Data;
using ChalanaChithram.CastService.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChalanaChithram.CastService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext dbContext = dbContext;

    [HttpGet]
    public async Task<IActionResult> GetAllPeople()
    {
        List<PersonDto> people = await dbContext.People
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new PersonDto
            {
                Id = x.Id,
                Name = x.Name,
                ProfileImageUrl = x.ProfileImageUrl,
                InstagramUrl = x.InstagramUrl,
                TwitterUrl = x.TwitterUrl,
                FacebookUrl = x.FacebookUrl,
                YoutubeUrl = x.YoutubeUrl
            })
            .ToListAsync();

        return Ok(people);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPersonById(int id)
    {
        PersonDto? person = await dbContext.People
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new PersonDto
            {
                Id = x.Id,
                Name = x.Name,
                ProfileImageUrl = x.ProfileImageUrl,
                InstagramUrl = x.InstagramUrl,
                TwitterUrl = x.TwitterUrl,
                FacebookUrl = x.FacebookUrl,
                YoutubeUrl = x.YoutubeUrl
            })
            .FirstOrDefaultAsync();

        if (person == null)
        {
            return NotFound(new { message = "Person not found." });
        }

        return Ok(person);
    }
}
