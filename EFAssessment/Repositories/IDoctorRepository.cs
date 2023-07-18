using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public interface IDoctorRepository
    {
        public bool AvailabilityIsExist(Guid guid);
        public Task Add(Doctor doctor);
        public Task<Doctor?> getByDoctorId(Guid doctorId);
        public Task<List<Doctor>> GetAll();
    }
}
