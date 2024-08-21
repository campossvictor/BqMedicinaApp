using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class AttendantRepository : UserRepository, IAttendantRepository
{
    public AttendantRepository(AppDbContext context) : base(context)
    {
    }
}