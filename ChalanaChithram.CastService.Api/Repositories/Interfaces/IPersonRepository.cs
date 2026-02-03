using ChalanaChithram.CastService.Api.Entities;

namespace ChalanaChithram.CastService.Api.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
    }
}
