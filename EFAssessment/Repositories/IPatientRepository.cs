using EFAssessment.Entities;

namespace EFAssessment.Repositories
{
    public interface IPatientRepository
    {
        public Task Add(Patient patient);
    }
}
