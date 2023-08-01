using EFAssessment.Controllers.Dtos;
using EFAssessment.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EFAssessment.Controllers
{
    [Route("/")]
  
    public class UserController : ControllerBase
    {
        private readonly JwtCreator _jwtCreator;
        public UserController(JwtCreator jwtCreator)
        {
            _jwtCreator = jwtCreator;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request.UserName == "admin")
                return Ok(_jwtCreator.GenerateJsonWebToken("admin"));
            return Unauthorized();
        }
    }

}
