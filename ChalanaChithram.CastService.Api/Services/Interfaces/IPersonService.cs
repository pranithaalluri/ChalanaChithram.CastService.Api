using ChalanaChithram.CastService.Api.Dtos;

namespace ChalanaChithram.CastService.Api.Services.Interfaces;

public interface IPersonService
{
    Task<List<PersonDto>> GetAllPeopleAsync();
    Task<PersonDto?> GetPersonByIdAsync(int id);
}
