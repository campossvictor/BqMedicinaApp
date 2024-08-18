namespace BqMedicinaApp.API.Models.DTOs;

public class PatientDTO : UserDTO
{
    public string MedicalHistory { get; set; }

    public string MedicalInsurance { get; set; }

    public string MedicalRecord { get; set; }
}