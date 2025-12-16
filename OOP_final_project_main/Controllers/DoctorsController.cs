using System;
using System.Collections.Generic;
using System.Linq;
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    public class DoctorController
    {
        private List<Doctor> _doctorList = new List<Doctor>();

        public void AddDoctor(string name, string specialty, int room)
        {
            _doctorList.Add(new Doctor(name, specialty, room));
            Console.WriteLine($"[SUCCESS] DOCTOR '{name}' HAS BEEN ADDED");
        }

        public void ViewAllDoctors()
        {
            Console.WriteLine("\n--- DOCTOR LIST ---");
            if (_doctorList.Count == 0) { 
                Console.WriteLine("EMPTY DATA"); 
                return; 
            }
            foreach (var item in _doctorList)
            {
                Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Specialty: {item.Specialty} | Room: {item.WorkRoom}");
            }
        }

        public void UpdateDoctor(Guid id, string name, string spec, int room)
        {
            var target = _doctorList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                target.Name = name;
                target.Specialty = spec;
                target.WorkRoom = room;
                Console.WriteLine("[SUCCESS] DOCTOR DATA HAS BEEN UPDATED");
            }
            else Console.WriteLine("[ERROR] ID NOT FOUND");
        }

        public void DeleteDoctor(Guid id)
        {
            var target = _doctorList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _doctorList.Remove(target);
                Console.WriteLine("[SUCCESS] DOCTOR DATA HAS BEEN ERASED");
            }
            else Console.WriteLine("[ERROR] ID NOT FOUND");
        }
    }
}