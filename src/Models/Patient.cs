using System.Security.Principal;

namespace BqMedicinaApp.API.Models;

public class Patient : User
{
    public DateTime BirthDate { get; set; }

    private ICollection<Scheduling> Schedulings { get; set; }
}