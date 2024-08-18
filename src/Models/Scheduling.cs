using System.Security.Principal;

namespace BqMedicinaApp.API.Models;

public class Scheduling
{
    public int SchedulingId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int UserId { get; set; }

    public string? Notes { get; set; }

    public TimeSpan HourAppointment { get; set; }
    
    public DateTime DateAppointment { get; set; }


    public User Attendant { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}