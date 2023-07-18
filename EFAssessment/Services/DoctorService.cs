using EFAssessment.Entities;
using EFAssessment.Repositories;
using EFAssessment.Controllers.Dtos;

namespace EFAssessment.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<Doctor>> Get(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _doctorRepository.GetAll();
            }
            var doctor = await _doctorRepository.getByName(name);
            if (doctor == null)
                return new List<Doctor> { };

            return new List<Doctor> { doctor };
        }

        public async Task AddDoctor(Doctor doctor)
        {
            await _doctorRepository.Add(doctor);
        }
    }
}
