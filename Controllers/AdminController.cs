using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine($"[Sukses] Admin '{name}' berhasil dibuat.");
        }

        // READ
        public void ViewAllAdmins()
        {
            Console.WriteLine("\n--- DAFTAR ADMIN ---");
            if (_adminList.Count == 0)
            {
                Console.WriteLine("Data kosong.");
                return;
            }
            foreach (var item in _adminList)
            {
                Console.WriteLine($"ID: {item.Id} | Nama: {item.Name} | Dept: {item.Department} | Level: {item.AccessLevel}");
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
                Console.WriteLine("[Sukses] Data Admin berhasil diupdate.");
            }
            else
            {
                Console.WriteLine("[Error] ID Admin tidak ditemukan!");
            }
        }

        // DELETE
        public void DeleteAdmin(Guid id)
        {
            var target = _adminList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _adminList.Remove(target);
                Console.WriteLine("[Sukses] Data Admin berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("[Error] ID Admin tidak ditemukan!");
            }
        }
    }
}