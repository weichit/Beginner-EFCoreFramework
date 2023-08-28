
using EFAssessment.Domain.Entities;
using EFAssessment.Controllers.Dtos;
using EFAssessment.Infrastructure.Repositories;
using EFAssessment.Domain.Exceptions;


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
        
        public async Task UpdatePatientReservation(Doctor doctor)
        {
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
            await _doctorRepository.UpdateReserved(doctor);
        }
        
    }
}
