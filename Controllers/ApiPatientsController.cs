using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPatientsController : ControllerBase
    {
        private static List<Patient> _patients = new List<Patient>
        {
            new Patient("Budi Santoso", 30, "Demam Tinggi")
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_patients);
        }

        [HttpPost]
        public IActionResult Create(string name, int age, string illness)
        {
            var pat = new Patient(name, age, illness);
            _patients.Add(pat);
            return Ok(pat);
        }
    }
}