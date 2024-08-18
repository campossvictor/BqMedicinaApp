namespace BqMedicinaApp.API.Models;

public class Attendant : User
{
    public DateTime AdmissionDate { get; set; }

    public string Departament { get; set; }

    public Attendant()
    {
        IsAttendant = true;
    }
}