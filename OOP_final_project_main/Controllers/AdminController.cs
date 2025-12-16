using System;
using System.Collections.Generic;
using System.Linq;
using OOP_final_project;


namespace OOP_final_project.Controllers
{
    public class AdminController
    {
        private List<Admin> _adminList = new List<Admin>();

        // CREATE
        public void AddAdmin(string name, string department, int accessLevel)
        {
            Admin newAdmin = new Admin(name, department, accessLevel);
            _adminList.Add(newAdmin);
            Console.WriteLine($"[SUCCESS] ADMIN '{name}' HAS BEEN CREATED");
        }

        // READ
        public void ViewAllAdmins()
        {
            Console.WriteLine("\n--- ADMIN LIST ---");
            if (_adminList.Count == 0)
            {
                Console.WriteLine("EMPTY DATA");
                return;
            }
            foreach (var item in _adminList)
            {
                Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Dept: {item.Department} | Level: {item.AccessLevel}");
            }
        }

        // UPDATE
        public void UpdateAdmin(Guid id, string name, string dept, int level)
        {
            var target = _adminList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                target.Name = name;
                target.Department = dept;
                target.AccessLevel = level;
                Console.WriteLine("[SUCCESS] ADMIN DATA UPDATED.");
            }
            else
            {
                Console.WriteLine("[ERROR] ADMIN DATA NOT FOUND");
            }
        }

        public void DeleteAdmin(Guid id)
        {
            var target = _adminList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _adminList.Remove(target);
                Console.WriteLine("[SUCCESS] ADMIN DATA SUCCESSFULLY DELETED.");
            }
            else
            {
                Console.WriteLine("[ERROR] ADMIN ID NOT FOUND!");
            }
        }
    }
}