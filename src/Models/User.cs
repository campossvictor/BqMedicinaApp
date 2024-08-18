namespace BqMedicinaApp.API.Models;

public class User
{
    public int UserId { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }

    public string Cel { get; set; }
    
    public string Name { get; set; }
    
    public string Document { get; set; }
    
    public DateTime Registration { get; set; }
    
    public DateTime? BirthDate { get; set; }
}