using System;
using System.Collections.Generic;
using System.Linq;
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    public class PatientController
    {
        private List<Patient> _patientList = new List<Patient>();

        public void AddPatient(string name, int age, string illness)
        {
            _patientList.Add(new Patient(name, age, illness));
            Console.WriteLine($"[SUCCESS] PATIENT '{name}' HAS BEEN ADDED");
        }

        public void ViewAllPatients()
        {
            Console.WriteLine("\n--- PATIENT LIST ---");
            if (_patientList.Count == 0) { 
                Console.WriteLine("EMPTY DATA"); 
                return; 
            }
            foreach (var item in _patientList)
            {
                Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Age: {item.Age} | Illness: {item.Illness}");
            }
        }

        public void UpdatePatient(Guid id, string name, int age, string illness)
        {
            var target = _patientList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                target.Name = name;
                target.Age = age;
                target.Illness = illness;
                Console.WriteLine("[SUCCESS] PATIENT DATA HAS BEEN UPDATED");
            }
            else Console.WriteLine("[ERROR] ID NOT FOUND");
        }

        public void DeletePatient(Guid id)
        {
            var target = _patientList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _patientList.Remove(target);
                Console.WriteLine("[SUCCESS] PATIENT DATA HAS BEEN DELETED");
            }
            else Console.WriteLine("[ERROR] ID NOT FOUND");
        }
    }
}