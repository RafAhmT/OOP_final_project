using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_final_project.Controllers
{
    public class PatientController
    {
        private List<Patient> _patientList = new List<Patient>();

        public void AddPatient(string name, int age, string illness)
        {
            _patientList.Add(new Patient(name, age, illness));
            Console.WriteLine($"[Sukses] Pasien '{name}' berhasil ditambahkan.");
        }

        public void ViewAllPatients()
        {
            Console.WriteLine("\n--- DAFTAR PASIEN ---");
            if (_patientList.Count == 0) { Console.WriteLine("Data kosong."); return; }
            foreach (var item in _patientList)
            {
                Console.WriteLine($"ID: {item.Id} | Nama: {item.Name} | Umur: {item.Age} | Sakit: {item.Illness}");
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
                Console.WriteLine("[Sukses] Data Pasien berhasil diupdate.");
            }
            else Console.WriteLine("[Error] ID tidak ditemukan.");
        }

        public void DeletePatient(Guid id)
        {
            var target = _patientList.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                _patientList.Remove(target);
                Console.WriteLine("[Sukses] Data Pasien berhasil dihapus.");
            }
            else Console.WriteLine("[Error] ID tidak ditemukan.");
        }
    }
}