using EFAssessment.Domain.Entities;

namespace EFAssessment.Services
{
    public interface IDoctorService
    {
        //public Task CreateDoctor(Doctor doctor);
        public Task<List<Doctor>> Get(Guid? doctorId);
        public Task AddDoctor(Doctor doctor);
        public Task UpdatePatientReservation(Doctor doctor);
    }
}
