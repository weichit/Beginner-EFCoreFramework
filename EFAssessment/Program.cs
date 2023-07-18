using EFAssessment.Database;
using EFAssessment.Services;
using EFAssessment.Repositories;
using EFAssessment.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppointmentDb(builder.Configuration);
builder.Services.AddControllers();
// controllers -- repo -- services
builder.Services.AddTransient<IDoctorRepository, DoctorRepo>();
builder.Services.AddTransient<IDoctorService, DoctorService>();

builder.Services.AddTransient<IPatientRepository, PatientRepo>();
builder.Services.AddTransient<IPatientService, PatientService>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
