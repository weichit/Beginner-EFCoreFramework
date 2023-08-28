using EFAssessment.Domain.Contracts;
using EFAssessment.Domain.Exceptions;
using EFAssessment.Domain.Entities;
using EFAssessment.Application.Usecases;
using EFAssessment.Services;
using Moq;
using EFAssessment.Controllers.Dtos;
using EFAssessment.Infrastructure.Repositories;

namespace UnitTestIntermediateAssessment.Services
{
    public class PatientServicesTest
    {
        [Fact]
        public async Task AddPatient_WhenPatientNameEmpty_ShouldThrowException()
        {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>(); 
            var doctorRepository = new Mock<IDoctorRepository>();
            var patientService = new CreatePatient(patientRepository.Object, doctorRepository.Object);
            //Act
            await Assert.ThrowsAsync<PatientNameEmptyException>(async () => await patientService.Execute(new CreatePatientRequest { }));
        }

        [Fact]
        public async Task AddPatient_WhenIdExists_ShouldWork()
        {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>();
            var doctorRepository = new Mock<IDoctorRepository>();
            var testPatient = new CreatePatientRequest { Id = Guid.NewGuid() };
           
            patientRepository.Setup(patientRepository => patientRepository.AvailabilityIsExist(testPatient.Id)).Returns(false);
            var patientService = new CreatePatient(patientRepository.Object, doctorRepository.Object);

            //Act
            await patientService.Execute(testPatient);

            //Assert
            patientRepository.Verify(x => x.Add(It.IsAny<Patient>()));

        }
        
        [Fact]
        public async Task AddPatient_WhenCheckSlotAvailabilityShouldWork()
        {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>();
            var doctorRepository = new Mock<IDoctorRepository>();
            var testPatient = new CreatePatientRequest { SlotId = Guid.NewGuid() };

            patientRepository.Setup(patientRepository => patientRepository.CheckSlotAvailability(testPatient.SlotId)).Returns(true);
            var patientService = new CreatePatient(patientRepository.Object, doctorRepository.Object);

            //Act
            await patientService.Execute(testPatient);
            //await Assert.ThrowsAsync<ReservationNotOpenException()> (async () => await patientService.AddPatient(new Patient { }));
            
            //Assert
            patientRepository.Verify(x => x.Add(It.IsAny<Patient>()));

        }
        
    }
}