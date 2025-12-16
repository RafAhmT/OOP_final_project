using Microsoft.AspNetCore.Mvc;
using OOP_Assigment_classlib;
using OOP_final_project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_final_project
{
    public class UI
    {
        private AdminController adminCtrl;
        private NurseController nurseCtrl;
        private DoctorController docCtrl;
        private PatientController patCtrl;

        // Define field configurations for each entity
        private Dictionary<string, List<FieldConfig>> entityFields = new Dictionary<string, List<FieldConfig>>()
    {
        { "admin", new List<FieldConfig>
            {
                new FieldConfig("Name", FieldType.String),
                new FieldConfig("Department", FieldType.String),
                new FieldConfig("Access Level", FieldType.Int)
            }
        },
        { "nurse", new List<FieldConfig>
            {
                new FieldConfig("Name", FieldType.String),
                new FieldConfig("Work Area", FieldType.String)
            }
        },
        { "doctor", new List<FieldConfig>
            {
                new FieldConfig("Name", FieldType.String),
                new FieldConfig("Specialty", FieldType.String),
                new FieldConfig("Room Number", FieldType.Int)
            }
        },
        { "patient", new List<FieldConfig>
            {
                new FieldConfig("Name", FieldType.String),
                new FieldConfig("Age", FieldType.Int),
                new FieldConfig("Illness", FieldType.String)
            }
        }
    };

        void init_controller()
        {
            adminCtrl = new AdminController();
            nurseCtrl = new NurseController();
            docCtrl = new DoctorController();
            patCtrl = new PatientController();
        }

        public void submenu(dynamic controller, string entity)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"=== MANAGE {entity.ToUpper()} ===");
                Console.WriteLine($"1. Create {entity}");
                Console.WriteLine($"2. Read All {entity}s");
                Console.WriteLine($"3. Update {entity}");
                Console.WriteLine($"4. Delete {entity}");
                Console.WriteLine($"5. Back");
                Console.Write("Choice > ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateEntity(controller, entity);
                        Console.ReadKey();
                        break;
                    case "2":
                        ReadAllEntities(controller, entity);
                        Console.ReadKey();
                        break;
                    case "3":
                        UpdateEntity(controller, entity);
                        Console.ReadKey();
                        break;
                    case "4":
                        DeleteEntity(controller, entity);
                        Console.ReadKey();
                        break;
                    case "5":
                        back = true; // Simply exit the loop
                        break;
                }
            }
        }

        private List<object> CollectInput(string entity)
        {
            List<object> values = new List<object>();

            if (entityFields.ContainsKey(entity.ToLower()))
            {
                foreach (var field in entityFields[entity.ToLower()])
                {
                    Console.Write($"{field.Name}: ");
                    string input = Console.ReadLine();


                    if (field.Type == FieldType.Int)
                    {
                        while (!int.TryParse(input, out int intValue))
                        {
                            Console.Write($"Invalid input. Please enter a valid number for {field.Name}: ");
                            input = Console.ReadLine();
                        }
                        values.Add(int.Parse(input));
                    }
                    else
                    {
                        values.Add(input);
                    }
                }
            }

            return values;
        }

        private void CreateEntity(dynamic controller, string entity)
        {
            List<object> values = CollectInput(entity);

            switch (entity.ToLower())
            {
                case "admin":
                    controller.AddAdmin((string)values[0], (string)values[1], (int)values[2]);
                    break;
                case "nurse":
                    controller.AddNurse((string)values[0], (string)values[1]);
                    break;
                case "doctor":
                    controller.AddDoctor((string)values[0], (string)values[1], (int)values[2]);
                    break;
                case "patient":
                    controller.AddPatient((string)values[0], (int)values[1], (string)values[2]);
                    break;
            }
        }

        private void ReadAllEntities(dynamic controller, string entity)
        {
            switch (entity.ToLower())
            {
                case "admin":
                    controller.ViewAllAdmins();
                    break;
                case "nurse":
                    controller.ViewAllNurses();
                    break;
                case "doctor":
                    controller.ViewAllDoctors();
                    break;
                case "patient":
                    controller.ViewAllPatients();
                    break;
            }
        }

        private void UpdateEntity(dynamic controller, string entity)
        {
            ReadAllEntities(controller, entity);
            Console.Write($"\nEnter {entity} ID to edit: ");

            if (Guid.TryParse(Console.ReadLine(), out Guid idEdit))
            {
                List<object> values = CollectInput(entity);

                switch (entity.ToLower())
                {
                    case "admin":
                        controller.UpdateAdmin(idEdit, (string)values[0], (string)values[1], (int)values[2]);
                        break;
                    case "nurse":
                        controller.UpdateNurse(idEdit, (string)values[0], (string)values[1]);
                        break;
                    case "doctor":
                        controller.UpdateDoctor(idEdit, (string)values[0], (string)values[1], (int)values[2]);
                        break;
                    case "patient":
                        controller.UpdatePatient(idEdit, (string)values[0], (int)values[1], (string)values[2]);
                        break;
                }
            }
        }

        private void DeleteEntity(dynamic controller, string entity)
        {
            ReadAllEntities(controller, entity);
            Console.Write($"\nEnter {entity} ID to delete: ");

            if (Guid.TryParse(Console.ReadLine(), out Guid idDel))
            {
                switch (entity.ToLower())
                {
                    case "admin":
                        controller.DeleteAdmin(idDel);
                        break;
                    case "nurse":
                        controller.DeleteNurse(idDel);
                        break;
                    case "doctor":
                        controller.DeleteDoctor(idDel);
                        break;
                    case "patient":
                        controller.DeletePatient(idDel);
                        break;
                }
            }
        }
        public void mainscreen()
        {
            UI ui = new UI();
            ui.init_controller();
            bool isrun = true;
            List<string> options = new List<string>()
            {
                "MANAGE ADMIN", "MANAGE NURSE",
                "MANAGE DOCTOR", "MANAGE PATIENT", "QUIT"
            };
            while (isrun)
            {
                Console.Clear();
                textdraw textdraw = new textdraw();
                textdraw.drawtitle("HOSPITAL APPLICATION", "CRUD Console Mode", false);
                textdraw.drawmultoption(options);
                textdraw.drawtextnole("Select Option >");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "MANAGE ADMIN":
                        ui.submenu(ui.adminCtrl, "admin");
                        break;
                    case "MANAGE NURSE":
                        ui.submenu(ui.nurseCtrl, "nurse");
                        break;
                    case "MANAGE DOCTOR":
                        ui.submenu(ui.docCtrl, "doctor");
                        break;
                    case "MANAGE PATIENT":
                        ui.submenu(ui.patCtrl, "patient");
                        break;
                    case "QUIT":
                        isrun = false;
                        break;
                    default:
                        textdraw.drawtext("Invalid option.");
                        Console.ReadKey();
                        break;
                }
            }
            Environment.Exit(0);
        }
    }

    public enum FieldType
    {
        String,
        Int
    }
    public class FieldConfig
    {
        public string Name { get; set; }
        public FieldType Type { get; set; }

        public FieldConfig(string name, FieldType type)
        {
            Name = name;
            Type = type;
        }
    }
}