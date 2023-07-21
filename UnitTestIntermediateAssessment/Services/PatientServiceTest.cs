using EFAssessment.Entities;
using EFAssessment.Repositories;
using EFAssessment.Services;
using Moq;

namespace UnitTestIntermediateAssessment.Services
{
    public class PatientServicesTest
    {
        [Fact]
        public async Task AddPatient_WhenPatientNameEmpty_ShouldThrowException()
        {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>();         
            var patientService = new PatientService(patientRepository.Object);
            //Act
            await Assert.ThrowsAsync<PatientNameEmptyException>(async () => await patientService.AddPatient(new Patient { }));
        }

        [Fact]
        public async Task AddPatient_WhenIdExists_ShouldWork()
        {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>();
            var testPatient = new Patient { Id = Guid.NewGuid() };
           
            patientRepository.Setup(patientRepository => patientRepository.AvailabilityIsExist(testPatient.Id)).Returns(false);
            var patientService = new PatientService(patientRepository.Object);

            //Act
            await patientService.AddPatient(testPatient);

            //Assert
            patientRepository.Verify(x => x.Add(It.IsAny<Patient>()));

        }
        
        [Fact]
        public async Task AddPatient_WhenCheckSlotAvailabilityShouldWork()
        {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>();
            var testPatient = new Patient { SlotId = Guid.NewGuid() };

            patientRepository.Setup(patientRepository => patientRepository.CheckSlotAvailability(testPatient.SlotId)).Returns(true);
            var patientService = new PatientService(patientRepository.Object);

            //Act
            await patientService.AddPatient(testPatient);
            //await Assert.ThrowsAsync<ReservationNotOpenException()> (async () => await patientService.AddPatient(new Patient { }));
            
            //Assert
            patientRepository.Verify(x => x.Add(It.IsAny<Patient>()));

        }
        
    }
}