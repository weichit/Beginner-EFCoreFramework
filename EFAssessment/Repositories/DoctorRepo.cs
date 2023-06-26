using EFAssessment.Database;
using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public class DoctorRepo : IDoctorRepository
    {
        private AppointmentDb _db;

        public DoctorRepo(AppointmentDb db)
        {
            _db = db;
        }

        public async Task Add(Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
        }

    }
}
