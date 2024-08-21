using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class PatientRepository : UserRepository, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }
}