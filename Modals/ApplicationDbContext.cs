using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WeCare_Api.Modals
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // One to One Relation Appointment, Patient
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithOne(a => a.Appointment)
                .HasForeignKey<Patient>(p => p.AppointmentId);

            // One to Many Relation Doctor, Clinic
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors);

            //One to Many Relation City, Area
            modelBuilder.Entity<Area>()
                 .HasOne(a => a.City)
                 .WithMany(c => c.Areas);

            ////One to Many Relation Clinic, Area
            modelBuilder.Entity<Clinic>()
                 .HasOne(c => c.Area)
                 .WithMany(a => a.Clinics);

            //// One to Many Relation Doctor, Patient
            modelBuilder.Entity<Doctor>()
                 .HasMany(p => p.Patients)
                 .WithOne(d => d.Doctor);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            modelBuilder.Entity<Doctor>()
              .Property(d => d.FullName)
              .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            modelBuilder.Entity<Appointment>()
              .Property(a => a.Reservation)
              .HasComputedColumnSql("[Title] + ' ' + [DayOfWeek]");
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
