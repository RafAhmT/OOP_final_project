using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDoctorsController : ControllerBase
    {
        private static List<Doctor> _doctors = new List<Doctor>
        {
            new Doctor("Dr. Strange", "Bedah Syaraf", 101)
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_doctors);
        }

        [HttpPost]
        public IActionResult Create(string name, string specialty, int room)
        {
            var doc = new Doctor(name, specialty, room);
            _doctors.Add(doc);
            return Ok(doc);
        }
    }
}