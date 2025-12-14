using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq; // PENTING: Perlu untuk menggunakan FirstOrDefault

namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDoctorsController : ControllerBase
    {
        // Data sementara (Static List)
        private static List<Doctor> _doctors = new List<Doctor>
        {
            // Contoh data
            new Doctor("Dr. Strange", "Bedah Syaraf", 101)
        };

        // 1. READ ALL: GET /api/ApiDoctors
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_doctors);
        }

        // 2. CREATE: POST /api/ApiDoctors
        [HttpPost]
        public IActionResult Create(string name, string specialty, int room)
        {
            var newDoc = new Doctor(name, specialty, room);
            _doctors.Add(newDoc);
            // Mengembalikan status 201 Created
            return CreatedAtAction(nameof(GetAll), new { id = newDoc.Id }, newDoc);
        }

        // 3. UPDATE: PUT /api/ApiDoctors/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, string name, string specialty, int room)
        {
            var existingDoc = _doctors.FirstOrDefault(d => d.Id == id);

            if (existingDoc == null)
            {
                // Mengembalikan status 404 Not Found
                return NotFound($"Doctor with ID {id} not found.");
            }

            // Update properti data lama
            existingDoc.Name = name;
            existingDoc.Specialty = specialty;
            existingDoc.WorkRoom = room;

            // Mengembalikan status 200 OK
            return Ok(existingDoc);
        }

        // 4. DELETE: DELETE /api/ApiDoctors/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var docToRemove = _doctors.FirstOrDefault(d => d.Id == id);

            if (docToRemove == null)
            {
                // Mengembalikan status 404 Not Found
                return NotFound($"Doctor with ID {id} not found.");
            }

            _doctors.Remove(docToRemove);

            // Mengembalikan status 204 No Content (berhasil dihapus)
            return NoContent();
        }
    }
}