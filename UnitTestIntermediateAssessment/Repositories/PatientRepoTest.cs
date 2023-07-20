using EFAssessment.Database;
using EFAssessment.Entities;
using EFAssessment.Repositories;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace UnitTestIntermediateAssessment.Repositories;

public class PatientRepoTest
{
    [Fact]
    public void PatientNameIsExist_ShouldReturnFalse()
    {
        //Arrange
        var testPatient = new Patient { Id = Guid.NewGuid() };
        var appointmentDatabase = new DbContextMock<AppointmentDb>(new DbContextOptionsBuilder<AppointmentDb>().Options);
        appointmentDatabase.CreateDbSetMock(db => db.Patients, new List<Patient> { testPatient } );
        var patientRepo = new PatientRepo(appointmentDatabase.Object);

        // Act
        var actual = patientRepo.AvailabilityIsExist(testPatient.Id);

        // Assert
        Assert.False(actual);
    }

}