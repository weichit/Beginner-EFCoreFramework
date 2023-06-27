using EFAssessment.Database;
using EFAssessment.Entities;

namespace EFAssessment.Repositories;

public class PatientRepo: IPatientRepository
{
    private readonly AppointmentDb _db;

    public PatientRepo(AppointmentDb db)
    {
        _db = db;
    }

    public async Task Add(Patient patient)
    {
        _db.Patients.Add(patient);
        await _db.SaveChangesAsync();
    }

}
