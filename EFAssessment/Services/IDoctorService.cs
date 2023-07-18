using EFAssessment.Entities;

namespace EFAssessment.Services
{
    public interface IDoctorService
    {
        //public Task CreateDoctor(Doctor doctor);
        public Task<List<Doctor>> Get(string? name);
        public Task AddDoctor(Doctor doctor);
    }
}
