namespace BqMedicinaApp.API.Models;

public class Specialty
{
    public int SpeciltyId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    
    public ISet<Doctor> Doctors { get; set; }
}