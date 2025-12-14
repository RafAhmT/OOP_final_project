using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System; // Diperlukan untuk Guid
using System.Linq; // Diperlukan untuk FirstOrDefault
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPatientsController : ControllerBase
    {
        // Data sementara (Static List)
        private static List<Patient> _patients = new List<Patient>
        {
            // Contoh data
            new Patient("Budi Santoso", 30, "Demam Tinggi")
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
                // Mengembalikan status 404 Not Found
                return NotFound($"Patient with ID {id} not found.");
            }

            // Update properti data lama
            existingPatient.Name = name;
            existingPatient.Age = age;
            existingPatient.Illness = illness;

            // Mengembalikan status 200 OK
            return Ok(existingPatient);
        }

        // 4. DELETE: DELETE /api/ApiPatients/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var patientToRemove = _patients.FirstOrDefault(p => p.Id == id);

            if (patientToRemove == null)
            {
                // Mengembalikan status 404 Not Found
                return NotFound($"Patient with ID {id} not found.");
            }

            _patients.Remove(patientToRemove);

            // Mengembalikan status 204 No Content (berhasil dihapus)
            return NoContent();
        }
    }
}