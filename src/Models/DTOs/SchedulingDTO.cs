namespace BqMedicinaApp.API.Models.DTOs;

public class SchedulingDTO
{
    public DateTime DateAppointment { get; set; }
    
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int AttendantId { get; set; }

    public string? Notes { get; set; }
}