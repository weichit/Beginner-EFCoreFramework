using EFAssessment.Database;
using EFAssessment.Services;
using EFAssessment.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppointmentDb(builder.Configuration);

builder.Services.AddTransient<IDoctorRepository, DoctorRepo>();
builder.Services.AddTransient<IDoctorService, DoctorService>();

builder.Services.AddTransient<IPatientRepository, PatientRepo>();
builder.Services.AddTransient<IPatientService, PatientService>();


builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
