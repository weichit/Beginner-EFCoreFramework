using EFAssessment.Entities;
using EFAssessment.Controllers;
using EFAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using EFAssessment.Database;
using Microsoft.EntityFrameworkCore;

namespace EFAssessment.Controllers
{
    [Controller]
    [Route("/patients")]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        private IDoctorService _doctorService;

        public PatientController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            await _patientService.AddPatient(patient);
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


