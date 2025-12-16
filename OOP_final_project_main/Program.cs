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
            Console.WriteLine("[1] Run as API Server");
            Console.WriteLine("[2] Run as Console App");
            Console.Write("Select Mode > ");

            string mode = Console.ReadLine();
            if (mode == "1") RunApiServer(args);
            else RunConsoleApp();
        }

        static void RunConsoleApp()
        {
            UI ui = new UI();
            ui.mainscreen();
        }
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