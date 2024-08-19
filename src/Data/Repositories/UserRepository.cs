using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class UserRepository : GenericCrudRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}