using EFAssessment.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFAssessment.Database;

public class AppointmentDb : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }

    public AppointmentDb(DbContextOptions<AppointmentDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Appointment_Db");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}

public static class DbExtension
{
    public static IServiceCollection AddAppointmentDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppointmentDb>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));
        });
        return services;
    }
}

