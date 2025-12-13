using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_final_project
{
    // --- Abstract Base Class ---
    public abstract class GlobalUser
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        protected GlobalUser()
        {
            Id = Guid.NewGuid();
        }

        protected GlobalUser(string name) : this()
        {
            Name = name;
        }
    }

    // --- CLASS BARU: Admin ---
    public class Admin : GlobalUser
    {
        // Atribut tambahan khusus Admin
        public string Department { get; set; }
        public int AccessLevel { get; set; } // Misal: 1 = Basic, 99 = SuperAdmin

        public Admin() : base() { }

        public Admin(string name, string department, int accessLevel) : base(name)
        {
            Department = department;
            AccessLevel = accessLevel;
        }
    }

    // --- Existing Classes ---
    public class Nurse : GlobalUser
    {
        public string WorkArea { get; set; }

        public Nurse() : base() { }

        public Nurse(string name, string workArea) : base(name)
        {
            WorkArea = workArea;
        }
    }

    public class Doctor : GlobalUser
    {
        public string Specialty { get; set; }
        public int WorkRoom { get; set; }

        public Doctor() : base() { }

        public Doctor(string name, string specialty, int workRoom) : base(name)
        {
            Specialty = specialty;
            WorkRoom = workRoom;
        }
    }

    public class Patient : GlobalUser
    {
        public string Illness { get; set; }
        public int Age { get; set; }
        public Guid? AssignedDoctorId { get; set; }
        private Doctor _assignedDoctor;
        public Doctor AssignedDoctor
        {
            get => _assignedDoctor;
            set
            {
                _assignedDoctor = value;
                AssignedDoctorId = value?.Id;
            }
        }

        public Patient() : base() { }

        public Patient(string name, int age, string illness) : base(name)
        {
            Age = age;
            Illness = illness;
        }
    }
}