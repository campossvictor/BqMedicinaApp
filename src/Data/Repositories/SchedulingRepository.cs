using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;
using Microsoft.EntityFrameworkCore;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class SchedulingRepository : GenericCrudRepository<Scheduling>, ISchedulingRepository
{
    public SchedulingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ICollection<Scheduling>> GetSchedulingByPatient(int PatientId)
    {
        if (PatientId <= 0)
        {
            throw new InvalidOperationException("Patient Id is null");
        }

        Patient? user = await _context.Patients.Where(p => p.Id == PatientId && p.IsPatient).FirstOrDefaultAsync();
        
        if (user is null)
        {
            throw new ArgumentNullException("Patient doesn't exist!");
        }

        var schedulings = _context.Schedulings.Where(s => s.PatientId == user.Id).ToList();

        return schedulings;
    }

    public async Task<ICollection<Scheduling>> GetSChedulingByDoctor(int DoctorId)
    {
        if (DoctorId <= 0)
        {
            throw new InvalidOperationException("Doctor Id is null");
        }

        Doctor? user = await _context.Doctors.Where(p => p.Id == DoctorId && p.IsDoctor).FirstOrDefaultAsync();
        
        if (user is null)
        {
            throw new ArgumentNullException("Doctor doesn't exist!");
        }

        var schedulings = _context.Schedulings.Where(s => s.DoctorId == user.Id).ToList();

        return schedulings;
    }
}