namespace BqMedicinaApp.API.Models;

public class Doctor : User
{
    public string Crm { get; set; }

    public int SpecialtyId { get; set; }
    
    public Specialty Specialty { get; set; }
    public ICollection<Scheduling> Schedulings { get; set; }
}