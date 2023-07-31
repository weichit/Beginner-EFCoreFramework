using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EFAssessment.Application.Usecases;
using EFAssessment.Domain.Entities;
using EFAssessment.Controllers.Dtos;

namespace EFAssessment.Controllers
{
    [Controller]
    [Route("/patients")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private CreatePatient _createPatient;
        private readonly ILogger<PatientController> _logger;
     
        public PatientController(CreatePatient createPatient, ILogger<PatientController> logger)
        {
            _createPatient = createPatient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePatientRequest patient)
        {
            _logger.LogDebug(" Booking requested by a patient !!! ");
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            await _createPatient.Execute(patient);

            var getDoctor = await _createPatient.CheckAvailability(patient.SlotId);
            List<Doctor> bookedDoctor = getDoctor.ToList();
            Doctor firstDoctor = bookedDoctor.First();

            _logger.LogInformation(" Booking successful !!! A simple notification message for both patient ${patient} and doctor ${doctor} at appointment ${time}. ", 
                patient.PatientName, firstDoctor.DoctorName, patient.ReversedAt);
            return Ok(" New Booking is Created ... ");
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var slotsResult = await _createPatient.GetAvailableSlots();
            if (slotsResult == null)
            {
                return BadRequest(" Not available slots now !!! ");
            }
            return Ok(slotsResult);
        }

    }
}


