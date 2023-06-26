using EFAssessment.Entities;

namespace EFAssessment.Services
{
    public interface IDoctorService
    {
        public Task CreateDoctor(Doctor doctor);
    }
}
