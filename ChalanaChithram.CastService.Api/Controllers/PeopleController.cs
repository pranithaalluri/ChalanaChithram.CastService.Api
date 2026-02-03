using ChalanaChithram.CastService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChalanaChithram.CastService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController(IPersonService personService) : ControllerBase
{
    private readonly IPersonService personService = personService;

    [HttpGet]
    public async Task<IActionResult> GetAllPeople()
    {
        return Ok(await personService.GetAllPeopleAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPersonById(int id)
    {
        var person = await personService.GetPersonByIdAsync(id);

        if (person == null)
        {
            return NotFound(new { message = "Person not found." });
        }

        return Ok(person);
    }
}
