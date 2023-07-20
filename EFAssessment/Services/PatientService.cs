using EFAssessment.Entities;
using EFAssessment.Repositories;
using EFAssessment.Services;

namespace EFAssessment.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Doctor>> GetAvailableSlots()
        {
            var slots = await _patientRepository.GetAvailableSlots();
            if (slots == null)
                return new List<Doctor> { };
            return new List<Doctor> { slots };
        }

        public async Task<List<Doctor>> CheckAvailability(Guid slotId)
        {
            var results = await _patientRepository.CheckAvailability(slotId);
            if (results == null)
                return new List<Doctor> { };
            return new List<Doctor> { results };
        }

        public async Task AddPatient(Patient patient)
        {
            // PatientName is not empty
            if (!string.IsNullOrEmpty(patient.PatientName))
            {
                throw new PatientNameEmptyException();
            }
            // Id used for booking must be unique
            var exists = _patientRepository.AvailabilityIsExist(patient.Id);
            if (exists)
            {
                throw new AvailabilityAlreadyExistsException(patient.Id);
            }
            // SlotId must be opened for reservation
            var checkResult = _patientRepository.CheckSlotAvailability(patient.SlotId);
            if (!checkResult)
            {
                throw new ReservationNotOpenException(patient.SlotId);
            }
           
            await _patientRepository.Add(patient);
        }
    }
}
