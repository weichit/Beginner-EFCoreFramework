using EFAssessment.Controllers.Dtos;
using EFAssessment.Services;
using EFAssessment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFAssessment.Controllers
{
    [Route("/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService )
        {
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
            return Ok("Doctor availability created ... ");
        }

    }
}
