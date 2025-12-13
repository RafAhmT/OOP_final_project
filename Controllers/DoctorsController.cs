using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_final_project.Controllers
{
    public class DoctorController
    {
        private List<Doctor> _doctorList = new List<Doctor>();

        public void AddDoctor(string name, string specialty, int room)
        {
            _doctorList.Add(new Doctor(name, specialty, room));
            Console.WriteLine($"[Sukses] Dokter '{name}' berhasil ditambahkan.");
        }

        public void ViewAllDoctors()
        {
            Console.WriteLine("\n--- DAFTAR DOKTER ---");
            if (_doctorList.Count == 0) { Console.WriteLine("Data kosong."); return; }
            foreach (var item in _doctorList)
            {
                Console.WriteLine($"ID: {item.Id} | Nama: {item.Name} | Spesialis: {item.Specialty} | Ruang: {item.WorkRoom}");
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
                Console.WriteLine("[Sukses] Data Dokter berhasil diupdate.");
            }
            else Console.WriteLine("[Error] ID tidak ditemukan.");
        }

        public void DeleteDoctor(Guid id)
        {
            var target = _doctorList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _doctorList.Remove(target);
                Console.WriteLine("[Sukses] Data Dokter berhasil dihapus.");
            }
            else Console.WriteLine("[Error] ID tidak ditemukan.");
        }
    }
}