using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class SpecialtyRepository : GenericCrudRepository<Specialty>, ISpecialtyRepository
{
    public SpecialtyRepository(AppDbContext context) : base(context)
    {
    }
}