using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System; 
using System.Linq; 
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPatientsController : ControllerBase
    {
        private static List<Patient> _patients = new List<Patient>
        {
            new Patient("Budi Santoso", 30, "Fever")
        };

        // 1. READ ALL: GET /api/ApiPatients
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_patients);
        }

        // 2. CREATE: POST /api/ApiPatients
        [HttpPost]
        public IActionResult Create(string name, int age, string illness)
        {
            var newPat = new Patient(name, age, illness);
            _patients.Add(newPat);
            // Mengembalikan status 201 Created
            return CreatedAtAction(nameof(GetAll), new { id = newPat.Id }, newPat);
        }

        // 3. UPDATE: PUT /api/ApiPatients/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, string name, int age, string illness)
        {
            var existingPatient = _patients.FirstOrDefault(p => p.Id == id);

            if (existingPatient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            existingPatient.Name = name;
            existingPatient.Age = age;
            existingPatient.Illness = illness;

            return Ok(existingPatient);
        }

        // 4. DELETE: DELETE /api/ApiPatients/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var patientToRemove = _patients.FirstOrDefault(p => p.Id == id);

            if (patientToRemove == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            _patients.Remove(patientToRemove);

            return NoContent();
        }
    }
}