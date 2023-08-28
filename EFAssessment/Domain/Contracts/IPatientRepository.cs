using EFAssessment.Domain.Entities;

namespace EFAssessment.Domain.Contracts
{
    public interface IPatientRepository
    {
        public Task Add(Patient patient);
        public bool AvailabilityIsExist(Guid id);
        public Task<Doctor?> GetAvailableSlots();
        public Task<Doctor?> CheckAvailability(Guid slotId);
        public bool CheckSlotAvailability(Guid slotId);
        //public Task UpdateReserved(Doctor doctor);  
    }
}
