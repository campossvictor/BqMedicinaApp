using System.Security.Principal;

namespace BqMedicinaApp.API.Models;

public class Patient : User
{
    public string? MedicalHistory { get; set; }

    public string? MedicalInsurance { get; set; }

    public string? MedicalRecord { get; set; }

    private ICollection<Scheduling> Schedulings { get; set; } = new List<Scheduling>();

    public Patient()
    {
        IsPatient = true;
    }
}