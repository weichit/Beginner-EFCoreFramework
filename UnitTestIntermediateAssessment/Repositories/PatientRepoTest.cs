using EFAssessment.Infrastructure.Database;
using EFAssessment.Domain.Entities;
using EFAssessment.Infrastructure.Repositories;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using EFAssessment.Controllers.Dtos;

namespace UnitTestIntermediateAssessment.Repositories;

public class PatientRepoTest
{
    [Fact]
    public void PatientNameIsExist_ShouldReturnFalse()
    {
        //Arrange
        var testPatient = new CreatePatientRequest { Id = Guid.NewGuid() };
        var appointmentDatabase = new DbContextMock<AppointmentDb>(new DbContextOptionsBuilder<AppointmentDb>().Options);
        appointmentDatabase.CreateDbSetMock(db => db.Patients, new List<Patient> {  } );
        var patientRepo = new PatientRepo(appointmentDatabase.Object);

        // Act
        var actual = patientRepo.AvailabilityIsExist(testPatient.Id);

        // Assert
        Assert.False(actual);
    }

}