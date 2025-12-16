using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAdminsController : ControllerBase
    {
        private static List<Admin> _admins = new List<Admin>
        {
            new Admin("Admin Default", "IT Support", 99)
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_admins);
        }

        [HttpPost]
        public IActionResult Create(string name, string department, int level)
        {
            var newAdmin = new Admin(name, department, level);
            _admins.Add(newAdmin);
            return CreatedAtAction(nameof(GetAll), new { id = newAdmin.Id }, newAdmin);
        }


        [HttpPut("{id}")]
        public IActionResult Update(Guid id, string name, string department, int level)
        {
            var existingAdmin = _admins.FirstOrDefault(a => a.Id == id);

            if (existingAdmin == null)
            {
                return NotFound($"Admin with ID {id} not found.");
            }

            existingAdmin.Name = name;
            existingAdmin.Department = department;
            existingAdmin.AccessLevel = level;

            return Ok(existingAdmin);
        }

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