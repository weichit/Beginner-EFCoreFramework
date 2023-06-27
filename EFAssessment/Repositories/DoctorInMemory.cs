using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public class DoctorInMemory : IDoctorRepository
    {
        private static readonly List<Doctor> Doctors = new();

        public async Task Add(Doctor doctor)
        {
            Doctors.Add(doctor);
        }
    }
}
