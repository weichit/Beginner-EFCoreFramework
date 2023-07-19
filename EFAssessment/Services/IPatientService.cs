using EFAssessment.Entities;

namespace EFAssessment.Services
{
    public interface IPatientService
    {
        public Task<List<Doctor>> GetAvailableSlots();
        public Task AddPatient(Patient patient);
        public Task<List<Doctor>> CheckAvailability(Guid slotId);

    }
}
