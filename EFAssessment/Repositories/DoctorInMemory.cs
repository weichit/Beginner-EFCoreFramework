using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public class DoctorInMemory : IDoctorRepository
    {
        private static List<Doctor> _doctors = new List<Doctor>();

        public async Task Add(Doctor doctor)
        {
            _doctors.Add(doctor);
        }
    }
}
