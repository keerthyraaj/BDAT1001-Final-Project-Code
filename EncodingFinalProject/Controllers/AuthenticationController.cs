using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncodingFinalProject.Models;
using EncodingFinalProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EncodingFinalProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Teacher model)
        {
            var student = _authenticateService.Authenticate(model.UserName, model.Password);
            if (student == null)
            {
                return BadRequest(new { Message = "invalid username or password" });
            }
            else
                return Ok(student);
        }
    }
}
