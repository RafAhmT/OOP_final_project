using System;
using System.Collections.Generic;
using System.Linq;
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    public class NurseController
    {
        private List<Nurse> _nurseList = new List<Nurse>();

        public void AddNurse(string name, string workArea)
        {
            _nurseList.Add(new Nurse(name, workArea));
            Console.WriteLine($"[SUCCESS] Nurse '{name}' HAS BEEN ADDED");
        }

        public void ViewAllNurses()
        {
            Console.WriteLine("\n--- NURSES LIST ---");
            if (_nurseList.Count == 0) {
                Console.WriteLine("EMPTY DATA"); 
                return; 
            }
            foreach (var item in _nurseList)
            {
                Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Area: {item.WorkArea}");
            }
        }

        public void UpdateNurse(Guid id, string name, string area)
        {
            var target = _nurseList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                target.Name = name;
                target.WorkArea = area;
                Console.WriteLine("[SUCCESS] NURSE DATA HAS BEEN UPDATED.");
            }
            else Console.WriteLine("[ERROR] ID NOT FOUND.");
        }

        public void DeleteNurse(Guid id)
        {
            var target = _nurseList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _nurseList.Remove(target);
                Console.WriteLine("[SUCCESS] NURSE DATA HAS BEEN DELETED");
            }
            else Console.WriteLine("[ERROR] ID NOT FOUND");
        }
    }
}