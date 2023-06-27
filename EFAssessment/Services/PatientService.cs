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

        public async Task CreatePatient(Patient patient)
        {
            await _patientRepository.Add(patient);
        }
    }
}
