using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncodingFinalProject.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EncodingFinalProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly LearningContext _context;

        public CourseController(LearningContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }
        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }
        [HttpGet, Route("/Course/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }
    }
}
