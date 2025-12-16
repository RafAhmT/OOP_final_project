using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq; // PENTING: Perlu LINQ untuk mencari/menghapus data
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAdminsController : ControllerBase
    {
        // Static agar data tidak hilang saat refresh browser
        private static List<Admin> _admins = new List<Admin>
        {
            // Data contoh sudah memiliki ID unik (Guid)
            new Admin("Admin Default", "IT Support", 99)
        };

        // 1. READ ALL: GET /api/ApiAdmins
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_admins);
        }

        // 2. CREATE: POST /api/ApiAdmins
        [HttpPost]
        public IActionResult Create(string name, string department, int level)
        {
            var newAdmin = new Admin(name, department, level);
            _admins.Add(newAdmin);
            // Mengembalikan status 201 Created
            return CreatedAtAction(nameof(GetAll), new { id = newAdmin.Id }, newAdmin);
        }

        // 3. UPDATE: PUT /api/ApiAdmins/{id}
        // Catatan: ID Admin diambil dari URL, data baru diambil dari Query/Form
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, string name, string department, int level)
        {
            var existingAdmin = _admins.FirstOrDefault(a => a.Id == id);

            if (existingAdmin == null)
            {
                return NotFound($"Admin with ID {id} not found.");
            }

            // Update properti data lama dengan data baru
            existingAdmin.Name = name;
            existingAdmin.Department = department;
            existingAdmin.AccessLevel = level;

            // Mengembalikan status 200 OK (berhasil diupdate)
            return Ok(existingAdmin);
        }

        // 4. DELETE: DELETE /api/ApiAdmins/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var adminToRemove = _admins.FirstOrDefault(a => a.Id == id);

            if (adminToRemove == null)
            {
                return NotFound($"Admin with ID {id} not found.");
            }

            _admins.Remove(adminToRemove);

            return NoContent();
        }
    }
}