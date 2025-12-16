using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System; 
using System.Linq; 
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNursesController : ControllerBase
    {
        private static List<Nurse> _nurses = new List<Nurse>
        {
            new Nurse("Nurse Siti", "UGD")
        };

        // 1. READ ALL: GET /api/ApiNurses
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nurses);
        }

        // 2. CREATE: POST /api/ApiNurses
        [HttpPost]
        public IActionResult Create(string name, string workArea)
        {
            var newNurse = new Nurse(name, workArea);
            _nurses.Add(newNurse);
            return CreatedAtAction(nameof(GetAll), new { id = newNurse.Id }, newNurse);
        }

        // 3. UPDATE: PUT /api/ApiNurses/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, string name, string workArea)
        {
            var existingNurse = _nurses.FirstOrDefault(n => n.Id == id);

            if (existingNurse == null)
            {
                return NotFound($"Nurse with ID {id} not found.");
            }

            // Update properti data lama
            existingNurse.Name = name;
            existingNurse.WorkArea = workArea;

            // Mengembalikan status 200 OK
            return Ok(existingNurse);
        }

        // 4. DELETE: DELETE /api/ApiNurses/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var nurseToRemove = _nurses.FirstOrDefault(n => n.Id == id);

            if (nurseToRemove == null)
            {
                // Mengembalikan status 404 Not Found
                return NotFound($"Nurse with ID {id} not found.");
            }

            _nurses.Remove(nurseToRemove);

            return NoContent();
        }
    }
}