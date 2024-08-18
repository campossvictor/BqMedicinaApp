namespace BqMedicinaApp.API.Models;

public class User
{
    public int Id { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }

    public string Cel { get; set; }
    
    public string Name { get; set; }
    
    public string Document { get; set; }

    public bool IsDoctor { get; set; } = false;
    public bool IsPatient { get; set; } = false;
    public bool IsAttendant { get; set; } = false;
    
    public DateTime Registration { get; set; }
    
    public DateTime? BirthDate { get; set; }

    public User()
    {
        Registration = DateTime.Now;
    }
}