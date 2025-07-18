using System;
using System.Collections.Generic;
using System.Linq;

using Al_Eaida_Domin.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer
{
    public class AppDBcontext : IdentityDbContext<User, IdentityRole, string>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Appoiontment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
           .HasOne(a => a.User)
           .WithMany(d => d.Appointments)
           .HasForeignKey(a => a.UserID);
            //MedicalVisit
            modelBuilder.Entity<MedicalVisit>()
          .HasOne(m => m.Patient)
          .WithMany(p => p.MedicalVisits)
          .HasForeignKey(m => m.PatientId);
            // 
            modelBuilder.Entity<Medicine>().
                Property(m => m.Price).HasColumnType("decimal(20,2)");

            modelBuilder.Entity<MedicalVisit>()
           .HasOne(m => m.user)
           .WithMany(d => d.medicalVisits)
           .HasForeignKey(m => m.UserID);
            //Invoice
            modelBuilder.Entity<Invoice>()
        .HasOne(i => i.Patient)
        .WithMany(p => p.Invoices)
        .HasForeignKey(i => i.PatientId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.User)
                .WithMany(u => u.CreatedInvoices)
                .HasForeignKey(i => i.CreatedBy);
            //IPrescriptionItem

            modelBuilder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Prescription)
                .WithMany(p => p.Items)
                .HasForeignKey(pi => pi.PrescriptionId);

            modelBuilder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Medicine)
                .WithMany(m => m.PrescriptionItems)
                .HasForeignKey(pi => pi.MedicineId);
            //Prescription
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Visit)
                .WithMany(v => v.Prescriptions)
                .HasForeignKey(p => p.VisitId);
            //invoiceItem
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Invoice)
                .WithMany(i => i.Items)
                .HasForeignKey(ii => ii.InvoiceId);


            // Decimal precision settings
            modelBuilder.Entity<InvoiceItem>()
                .Property(ii => ii.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Medicine>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Patient>()
         .HasIndex(p => p.FullName);

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => a.AppointmentDate);

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.CreatedAt);
            //User
            modelBuilder.Entity<RefreshToken>()
           .HasOne(r => r.User)
           .WithMany(u => u.RefreshTokens)
           .HasForeignKey(r => r.UserId)
           .OnDelete(DeleteBehavior.Cascade);



            // Default values and soft delete
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.FindProperty("IsDeleted") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>("IsDeleted")
                        .HasDefaultValue(false);
                }

                if (entityType.FindProperty("CreatedAt") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql("GETUTCDATE()");
                }
            }
            // Roles

            modelBuilder.Entity<IdentityRole>()
             .HasData(
                 new IdentityRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "Admin",
                     NormalizedName = "ADMIN".ToUpper()
                 },
                 new IdentityRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "Doctor",
                     NormalizedName = "Doctor".ToUpper()
                 },
                   new IdentityRole
                   {
                       Id = Guid.NewGuid().ToString(),
                       Name = "Receptionist",
                       NormalizedName = "Receptionist".ToUpper()
                   },
                   new IdentityRole
                   {
                       Id = Guid.NewGuid().ToString(),
                       Name = "Accountant ",
                       NormalizedName = "Accountant ".ToUpper()
                   }
             );

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalVisit> MedicalVisits { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}

