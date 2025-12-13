using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OOP_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNursesController : ControllerBase
    {
        private static List<Nurse> _nurses = new List<Nurse>
        {
            new Nurse("Suster Siti", "UGD")
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nurses);
        }

        [HttpPost]
        public IActionResult Create(string name, string workArea)
        {
            var newNurse = new Nurse(name, workArea);
            _nurses.Add(newNurse);
            return Ok(newNurse);
        }
    }
}