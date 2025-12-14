using Microsoft.EntityFrameworkCore;
using OOP_final_project.Data;
using System.Text.Json.Serialization;
using OOP_Assigment_classlib;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using OOP_final_project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- LAUNCHER ---
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("   HOSPITAL OOP PROJECT LAUNCHER   ");
            Console.WriteLine("===================================");
            Console.WriteLine("[1] Run as API Server (Brian's Task)");
            Console.WriteLine("[2] Run as Console App (Rafan's Task)");
            Console.Write("Select Mode > ");

            string mode = Console.ReadLine();
            if (mode == "1") RunApiServer(args);
            else RunConsoleApp();
        }

        // ==========================================
        // TUGAS RAFAN (CONSOLE UI - ENGLISH)
        // ==========================================
        static void RunConsoleApp()
        {
            // Inisialisasi 4 Controller Console untuk CRUD
            AdminController adminCtrl = new AdminController();
            NurseController nurseCtrl = new NurseController();
            DoctorController docCtrl = new DoctorController();
            PatientController patCtrl = new PatientController();

            bool isrun = true;
            while (isrun)
            {
                List<string> options = new List<string>()
                {
                    "LOGIN", "MANAGE ADMIN", "MANAGE NURSE",
                    "MANAGE DOCTOR", "MANAGE PATIENT", "QUIT"
                };

                Console.Clear();
                // Asumsi class textdraw ada dan berfungsi
                textdraw textdraw = new textdraw();
                textdraw.drawtitle("HOSPITAL APPLICATION", "CRUD Console Mode", false);
                textdraw.drawmultoption(options);
                textdraw.drawtextnole("Select Option >");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "LOGIN":
                        Console.WriteLine("Coming soon...");
                        Console.ReadKey();
                        break;
                    case "MANAGE ADMIN":
                        ManageAdminMenu(adminCtrl);
                        break;
                    case "MANAGE NURSE":
                        ManageNurseMenu(nurseCtrl);
                        break;
                    case "MANAGE DOCTOR":
                        ManageDoctorMenu(docCtrl);
                        break;
                    case "MANAGE PATIENT":
                        ManagePatientMenu(patCtrl);
                        break;
                    case "QUIT":
                        isrun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // --- SUB MENU: ADMIN ---
        static void ManageAdminMenu(AdminController ctrl)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== MANAGE ADMIN ===");
                Console.WriteLine("1. Create Admin");
                Console.WriteLine("2. Read All Admins");
                Console.WriteLine("3. Update Admin");
                Console.WriteLine("4. Delete Admin");
                Console.WriteLine("5. Back");
                Console.Write("Choice > ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: "); string name = Console.ReadLine();
                        Console.Write("Department: "); string dept = Console.ReadLine();
                        // Error handling sederhana untuk int
                        int level = 0;
                        if (!int.TryParse(Console.ReadLine(), out level)) level = 1;
                        ctrl.AddAdmin(name, dept, level);
                        Console.ReadKey();
                        break;
                    case "2":
                        ctrl.ViewAllAdmins();
                        Console.ReadKey();
                        break;
                    case "3":
                        ctrl.ViewAllAdmins();
                        Console.Write("\nEnter Admin ID to edit (Copy-Paste ID): ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idEdit))
                        {
                            Console.Write("New Name: "); string nName = Console.ReadLine();
                            Console.Write("New Dept: "); string nDept = Console.ReadLine();
                            Console.Write("New Level: "); int nLevel = int.Parse(Console.ReadLine());
                            ctrl.UpdateAdmin(idEdit, nName, nDept, nLevel);
                        }
                        else Console.WriteLine("Invalid ID Format!");
                        Console.ReadKey();
                        break;
                    case "4":
                        ctrl.ViewAllAdmins();
                        Console.Write("\nEnter Admin ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idDel))
                            ctrl.DeleteAdmin(idDel);
                        else Console.WriteLine("Invalid ID Format!");
                        Console.ReadKey();
                        break;
                    case "5": back = true; break;
                }
            }
        }

        // --- SUB MENU: NURSE ---
        static void ManageNurseMenu(NurseController ctrl)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== MANAGE NURSE ===");
                Console.WriteLine("1. Create Nurse");
                Console.WriteLine("2. Read All Nurses");
                Console.WriteLine("3. Update Nurse");
                Console.WriteLine("4. Delete Nurse");
                Console.WriteLine("5. Back");
                Console.Write("Choice > ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: "); string name = Console.ReadLine();
                        Console.Write("Work Area: "); string area = Console.ReadLine();
                        ctrl.AddNurse(name, area);
                        Console.ReadKey();
                        break;
                    case "2":
                        ctrl.ViewAllNurses();
                        Console.ReadKey();
                        break;
                    case "3":
                        ctrl.ViewAllNurses();
                        Console.Write("\nEnter Nurse ID to edit: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idEdit))
                        {
                            Console.Write("New Name: "); string nName = Console.ReadLine();
                            Console.Write("New Area: "); string nArea = Console.ReadLine();
                            ctrl.UpdateNurse(idEdit, nName, nArea);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        ctrl.ViewAllNurses();
                        Console.Write("\nEnter Nurse ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idDel)) ctrl.DeleteNurse(idDel);
                        Console.ReadKey();
                        break;
                    case "5": back = true; break;
                }
            }
        }

        // --- SUB MENU: DOCTOR ---
        static void ManageDoctorMenu(DoctorController ctrl)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== MANAGE DOCTOR ===");
                Console.WriteLine("1. Create Doctor");
                Console.WriteLine("2. Read All Doctors");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Back");
                Console.Write("Choice > ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: "); string name = Console.ReadLine();
                        Console.Write("Specialty: "); string spec = Console.ReadLine();
                        Console.Write("Room Number: "); int room = int.Parse(Console.ReadLine());
                        ctrl.AddDoctor(name, spec, room);
                        Console.ReadKey();
                        break;
                    case "2":
                        ctrl.ViewAllDoctors();
                        Console.ReadKey();
                        break;
                    case "3":
                        ctrl.ViewAllDoctors();
                        Console.Write("\nEnter Doctor ID to edit: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idEdit))
                        {
                            Console.Write("New Name: "); string nName = Console.ReadLine();
                            Console.Write("New Specialty: "); string nSpec = Console.ReadLine();
                            Console.Write("New Room: "); int nRoom = int.Parse(Console.ReadLine());
                            ctrl.UpdateDoctor(idEdit, nName, nSpec, nRoom);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        ctrl.ViewAllDoctors();
                        Console.Write("\nEnter Doctor ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idDel)) ctrl.DeleteDoctor(idDel);
                        Console.ReadKey();
                        break;
                    case "5": back = true; break;
                }
            }
        }

        // --- SUB MENU: PATIENT ---
        static void ManagePatientMenu(PatientController ctrl)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== MANAGE PATIENT ===");
                Console.WriteLine("1. Create Patient");
                Console.WriteLine("2. Read All Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Back");
                Console.Write("Choice > ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: "); string name = Console.ReadLine();
                        Console.Write("Age: "); int age = int.Parse(Console.ReadLine());
                        Console.Write("Illness: "); string ill = Console.ReadLine();
                        ctrl.AddPatient(name, age, ill);
                        Console.ReadKey();
                        break;
                    case "2":
                        ctrl.ViewAllPatients();
                        Console.ReadKey();
                        break;
                    case "3":
                        ctrl.ViewAllPatients();
                        Console.Write("\nEnter Patient ID to edit: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idEdit))
                        {
                            Console.Write("New Name: "); string nName = Console.ReadLine();
                            Console.Write("New Age: "); int nAge = int.Parse(Console.ReadLine());
                            Console.Write("New Illness: "); string nIll = Console.ReadLine();
                            ctrl.UpdatePatient(idEdit, nName, nAge, nIll);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        ctrl.ViewAllPatients();
                        Console.Write("\nEnter Patient ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idDel)) ctrl.DeletePatient(idDel);
                        Console.ReadKey();
                        break;
                    case "5": back = true; break;
                }
            }
        }

        // ==========================================
        // API SERVER (MODE 1 - TETAP SAMA)
        // ==========================================
        static void RunApiServer(string[] args)
        {
            Console.WriteLine("Starting Web API Server...");
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Perintah ini secara otomatis menemukan semua 4 ApiController Anda
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            Console.WriteLine("--------------------------------------------------");
            // Menggunakan port 5000 yang sesuai dengan komputer Anda
            Console.WriteLine("Swagger UI is ready at: http://localhost:5000/swagger");
            Console.WriteLine("--------------------------------------------------");
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Perintah ini secara otomatis memetakan semua route API Anda (GET, POST, PUT, DELETE)
            app.MapControllers();

            app.Run();
        }
    }
}