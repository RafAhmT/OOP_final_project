using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_final_project.Controllers
{
    public class NurseController
    {
        private List<Nurse> _nurseList = new List<Nurse>();

        public void AddNurse(string name, string workArea)
        {
            _nurseList.Add(new Nurse(name, workArea));
            Console.WriteLine($"[Sukses] Perawat '{name}' berhasil ditambahkan.");
        }

        public void ViewAllNurses()
        {
            Console.WriteLine("\n--- DAFTAR PERAWAT ---");
            if (_nurseList.Count == 0) { Console.WriteLine("Data kosong."); return; }
            foreach (var item in _nurseList)
            {
                Console.WriteLine($"ID: {item.Id} | Nama: {item.Name} | Area: {item.WorkArea}");
            }
        }

        public void UpdateNurse(Guid id, string name, string area)
        {
            var target = _nurseList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                target.Name = name;
                target.WorkArea = area;
                Console.WriteLine("[Sukses] Data Perawat berhasil diupdate.");
            }
            else Console.WriteLine("[Error] ID tidak ditemukan.");
        }

        public void DeleteNurse(Guid id)
        {
            var target = _nurseList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _nurseList.Remove(target);
                Console.WriteLine("[Sukses] Data Perawat berhasil dihapus.");
            }
            else Console.WriteLine("[Error] ID tidak ditemukan.");
        }
    }
}