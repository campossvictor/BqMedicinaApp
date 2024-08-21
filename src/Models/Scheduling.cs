using System.Security.Principal;
using System.Text.Json.Serialization;

namespace BqMedicinaApp.API.Models;

public class Scheduling
{
    public int SchedulingId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int AttendantId { get; set; }

    public string? Notes { get; set; }

    public TimeSpan HourAppointment { get; set; }
    
    public DateTime DateAppointment { get; set; }

    [JsonIgnore]
    public Attendant Attendant { get; set; }
    [JsonIgnore]
    public Patient Patient { get; set; }
    [JsonIgnore]
    public Doctor Doctor { get; set; }
}