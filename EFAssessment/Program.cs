using EFAssessment.Infrastructure.Database;
using EFAssessment.Services;
using EFAssessment.Repositories;
using EFAssessment.Controllers;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using EFAssessment.Security;
using EFAssessment.Domain.Contracts;
using EFAssessment.Application.Usecases;
using EFAssessment.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog( (context, services, configuration) =>
{
    configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);

}
);
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;

});
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddAppointmentAuthentication(builder.Configuration);

builder.Services.AddAppointmentDb(builder.Configuration);

// controllers -- repo -- services
builder.Services.AddTransient<IDoctorRepository, DoctorRepo>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<JwtCreator>();
builder.Services.AddTransient<IPatientRepository, PatientRepo>();
//builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<CreatePatient>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
  
app.Run();

public partial class Program { }
