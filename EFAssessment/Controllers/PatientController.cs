using EFAssessment.Entities;
using EFAssessment.Controllers;
using EFAssessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFAssessment.Controllers
{
    [Controller]
    [Route("/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
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

            await _patientService.CreatePatient(patient);
            return Ok("Booking Create ... ");
        }
    }
}


