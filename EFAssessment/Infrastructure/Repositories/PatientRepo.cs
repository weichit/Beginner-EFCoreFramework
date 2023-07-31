using EFAssessment.Infrastructure.Database;
using EFAssessment.Domain.Contracts;
using EFAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFAssessment.Infrastructure.Repositories;

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
        return _db.Patients.Any(x => x.Id == id);
    }

    public async Task<Doctor?> GetAvailableSlots()
    {
        return await _db.Doctors.Where(item => item.IsReversed == false).SingleOrDefaultAsync();
    }

    public async Task<Doctor?> CheckAvailability(Guid slotId)
    {
        return await _db.Doctors.Where(item => item.Id == slotId && item.IsReversed == false).SingleOrDefaultAsync();
    }

    public bool CheckSlotAvailability(Guid slotId)
    {
        return _db.Doctors.Any(item => item.Id == slotId && item.IsReversed == false);
    }

}
