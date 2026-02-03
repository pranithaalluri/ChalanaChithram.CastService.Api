using ChalanaChithram.CastService.Api.Dtos;
using ChalanaChithram.CastService.Api.Entities;
using ChalanaChithram.CastService.Api.Repositories.Interfaces;
using ChalanaChithram.CastService.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChalanaChithram.CastService.Api.Services;

public class PersonService(
    IPersonRepository personRepository,
    ILogger<PersonService> logger) : IPersonService
{
    private readonly IPersonRepository personRepository = personRepository;
    private readonly ILogger<PersonService> logger = logger;

    public async Task<List<PersonDto>> GetAllPeopleAsync()
    {
        try
        {
            List<Person> people = await personRepository.GetAllAsync();

            return people.Select(MapToDto).ToList();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching people list");
            throw;
        }
    }

    public async Task<PersonDto?> GetPersonByIdAsync(int id)
    {
        try
        {
            Person? person = await personRepository.GetByIdAsync(id);

            return person == null ? null : MapToDto(person);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching person with id {PersonId}", id);
            throw;
        }
    }

    private static PersonDto MapToDto(Person person)
    {
        return new PersonDto
        {
            Id = person.Id,
            Name = person.Name,
            ProfileImage = person.ProfileImage,
            InstagramUrl = person.InstagramUrl,
            TwitterUrl = person.TwitterUrl,
            FacebookUrl = person.FacebookUrl,
            YoutubeUrl = person.YoutubeUrl
        };
    }
}
