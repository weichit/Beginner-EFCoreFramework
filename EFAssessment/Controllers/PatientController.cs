using EFAssessment.Entities;
using EFAssessment.Controllers;
using EFAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using EFAssessment.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EFAssessment.Controllers
{
    [Controller]
    [Route("/patients")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;
     
        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
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

            await _patientService.AddPatient(patient);

            var getDoctor = await _patientService.CheckAvailability(patient.SlotId);
            List<Doctor> bookedDoctor = getDoctor.ToList();
            Doctor firstDoctor = bookedDoctor.First();

            _logger.LogInformation(" Booking successful !!! A simple notification message for both patient ${patient} and doctor ${doctor} at appointment ${time}. ", 
                patient.PatientName, firstDoctor.DoctorName, patient.ReversedAt);
            return Ok(" New Booking is Created ... ");
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var slotsResult = await _patientService.GetAvailableSlots();
            if (slotsResult == null)
            {
                return BadRequest(" Not available slots now !!! ");
            }
            return Ok(slotsResult);
        }

    }
}


