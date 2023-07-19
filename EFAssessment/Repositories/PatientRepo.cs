using EFAssessment.Database;
using EFAssessment.Entities;
using Microsoft.EntityFrameworkCore;

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

    public bool AvailabilityIsExist(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Doctor?> GetAvailableSlots()
    {
        return await _db.Doctors.Where(item => item.IsReversed == false).SingleOrDefaultAsync();
    }

    public async Task<Doctor?> CheckAvailability(Guid slotId)
    {
        return await _db.Doctors.Where(item => item.Id == slotId && item.IsReversed == false).SingleOrDefaultAsync();
    }

}
