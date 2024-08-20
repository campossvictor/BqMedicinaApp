using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Generic;

namespace BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;

public interface ISchedulingRepository : IGenericCrudRepository<Scheduling>
{
    Task<ICollection<Scheduling>> GetSchedulingByPatient(int PatientId);
    
    Task<ICollection<Scheduling>> GetSChedulingByDoctor(int DoctorId);
}