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

        public async Task<List<Doctor>> Get(Guid? doctorId)
        {
            /*if (string.IsNullOrEmpty(name))
            {
                return await _doctorRepository.GetAll();
            }*/
            var doctor = await _doctorRepository.getByDoctorId((Guid)doctorId);
            if (doctor == null)
                return new List<Doctor> { };

            return new List<Doctor> { doctor };
        }

        public async Task AddDoctor(Doctor doctor)
        {
            // DoctorName and DoctorId are not empty
            if (!string.IsNullOrEmpty(doctor.DoctorName))
            {
                throw new DoctorNameEmptyException();
            }
            // Id must be unique as a new slot
            var exists = _doctorRepository.AvailabilityIsExist(doctor.Id);
            if (exists)
            {
                throw new AvailabilityAlreadyExistsException(doctor.Id);
            }
            await _doctorRepository.Add(doctor);
        }
    }
}
