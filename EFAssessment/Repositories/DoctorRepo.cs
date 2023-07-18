using EFAssessment.Database;
using EFAssessment.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Doctor?> getByName(string name)
        {
            return await _db.Doctors.Where(item => item.DoctorName == name).SingleOrDefaultAsync();
        }

        public async Task<List<Doctor>> GetAll()
        {
            return _db.Doctors.ToList();
        }
    }
}
