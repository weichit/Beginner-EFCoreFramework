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
        private readonly IPatientService _patientService;
        private AppointmentDb _db;
        public PatientController(AppointmentDb db, IPatientService patientService)
        {
            _db = db;
            _patientService = patientService;
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

            await _patientService.CreatePatient(patient);
            _db.Patients.Add(patient);  
           
            await _db.SaveChangesAsync();
            return Ok("Booking Create ... ");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctor = await _db.Doctors.Where(item => item.IsReversed == false).SingleOrDefaultAsync();
            return Ok(doctor);
        }

    }
}


