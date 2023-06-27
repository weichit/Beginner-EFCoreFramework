using EFAssessment.Entities;

namespace EFAssessment.Services
{
    public interface IPatientService
    {
        public Task CreatePatient(Patient patient);
    }
}
