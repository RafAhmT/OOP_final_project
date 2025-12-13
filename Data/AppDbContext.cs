using Microsoft.EntityFrameworkCore;

namespace OOP_final_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GlobalUser> GlobalUsers { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.AssignedDoctor)
                .WithMany()
                .HasForeignKey(p => p.AssignedDoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}