namespace BqMedicinaApp.API.Models.DTOs;

public class DoctorDTO : UserDTO
{
    public string Crm { get; set; }

    public int SpecialtyId { get; set; }
}