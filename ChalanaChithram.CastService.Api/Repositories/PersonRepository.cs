using ChalanaChithram.CastService.Api.Data;
using ChalanaChithram.CastService.Api.Entities;
using ChalanaChithram.CastService.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChalanaChithram.CastService.Api.Repositories;

public class PersonRepository(AppDbContext dbContext) : IPersonRepository
{
    public async Task<List<Person>> GetAllAsync()
    {
        return await dbContext.People
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await dbContext.People
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
