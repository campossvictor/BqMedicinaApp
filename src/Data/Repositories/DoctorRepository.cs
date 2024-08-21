using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class DoctorRepository : UserRepository, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }
}