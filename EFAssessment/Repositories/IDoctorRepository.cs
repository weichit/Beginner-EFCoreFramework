using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public interface IDoctorRepository
    {
        public Task Add(Doctor doctor);
    }
}
