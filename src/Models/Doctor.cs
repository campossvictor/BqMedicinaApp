using System.Text.Json.Serialization;

namespace BqMedicinaApp.API.Models;

public class Doctor : User
{
    public string Crm { get; set; }

    public int SpecialtyId { get; set; }
    
    [JsonIgnore]
    public Specialty Specialty { get; set; }
    
    [JsonIgnore]
    public ICollection<Scheduling> Schedulings { get; set; } = new List<Scheduling>();

    public Doctor()
    {
        IsDoctor = true;
    }
}