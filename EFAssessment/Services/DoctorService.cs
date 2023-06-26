using EFAssessment.Entities;
using EFAssessment.Repositories;

namespace EFAssessment.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        /*
        public async Task Create(string doctorName)
        {
            var doctor = new Doctor { DoctorName = doctorName, Id = Guid.NewGuid(), };

            await _doctorRepository.Add(doctor);
        }
        */
        public async Task CreateDoctor(Doctor doctor)
        {
            await _doctorRepository.Add(doctor);
        }
    }
}
