using EFAssessment.Controllers.Dtos;
using EFAssessment.Services;
using EFAssessment.Entities;
using Microsoft.AspNetCore.Mvc;
using EFAssessment.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFAssessment.Controllers
{
    [Controller]
    [Route("/doctors")]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _doctorService;
        
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
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

            await _doctorService.AddDoctor(doctor);
            return Ok(" New timeslot is created !!! ");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            var doctorsResult = await _doctorService.Get(name);
            if (doctorsResult == null)
                return BadRequest(" DoctorName not found !!! ");
            return Ok(doctorsResult);
        }
    }
}
