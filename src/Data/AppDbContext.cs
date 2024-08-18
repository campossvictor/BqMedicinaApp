using BqMedicinaApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BqMedicinaApp.API.src.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Attendant> Attendants { get; set; }
    public DbSet<Scheduling> Schedulings { get; set; }
    public DbSet<Specialty> Specialties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specialty>(op =>
        {
            op.HasKey(o => o.SpeciltyId);
        });
    }
}