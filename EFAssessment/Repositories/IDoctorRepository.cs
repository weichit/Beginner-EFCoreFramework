using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public interface IDoctorRepository
    {
        public Task Add(Doctor doctor);
        public Task<Doctor?> getByName(string name);
        public Task<List<Doctor>> GetAll();
    }
}
