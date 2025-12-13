using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAdminsController : ControllerBase
    {
        // Static agar data tidak hilang saat refresh browser
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
            return Ok(newAdmin);
        }
    }
}