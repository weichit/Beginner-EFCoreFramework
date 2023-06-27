using EFAssessment.Controllers.Dtos;
using EFAssessment.Services;
using EFAssessment.Entities;
using Microsoft.AspNetCore.Mvc;
using EFAssessment.Database;
using Microsoft.EntityFrameworkCore;

namespace EFAssessment.Controllers
{
    [Controller]
    [Route("/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private AppointmentDb _db;

        public DoctorController(AppointmentDb db, IDoctorService doctorService )
        {
            _db = db;
            _doctorService = doctorService;
        }

        [HttpPost]
        /*
        public async Task<IActionResult> Post([FromBody] CreateDoctorRequest request)
        {
            await _doctorService.Create(request.DoctorName);
            return Ok("Doctor availability created ... ");
        }
        */
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(ValueTask => ValueTask.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            await _doctorService.CreateDoctor(doctor);
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
            return Ok("Doctor availability created ... ");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Ok(_db.Doctors.ToList());    
            }
            var doctor = await _db.Doctors.Where(item => item.DoctorName == name).SingleOrDefaultAsync();
            return Ok(doctor);
        }

    }
}
