﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cmsRestApi.Models
{
    public partial class ClinicManagementSystemDBContext : DbContext
    {
        public ClinicManagementSystemDBContext()
        {
        }

        public ClinicManagementSystemDBContext(DbContextOptions<ClinicManagementSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAppointment> TblAppointment { get; set; }
        public virtual DbSet<TblDoctor> TblDoctor { get; set; }
        public virtual DbSet<TblLabReport> TblLabReport { get; set; }
        public virtual DbSet<TblMasterLabTest> TblMasterLabTest { get; set; }
        public virtual DbSet<TblMasterMedicine> TblMasterMedicine { get; set; }
        public virtual DbSet<TblPatient> TblPatient { get; set; }
        public virtual DbSet<TblPatientLog> TblPatientLog { get; set; }
        public virtual DbSet<TblPayment> TblPayment { get; set; }
        public virtual DbSet<TblPrescriptionMedicine> TblPrescriptionMedicine { get; set; }
        public virtual DbSet<TblPrescriptionTest> TblPrescriptionTest { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblSpecialization> TblSpecialization { get; set; }
        public virtual DbSet<TblStaff> TblStaff { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ASHIKAHUSSAIN\\SQLEXPRESS; Initial Catalog=ClinicManagementSystemDB; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAppointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__TblAppoi__8ECDFCC28239C024");

                entity.Property(e => e.DateofAppointment).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TblAppoin__Docto__45F365D3");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TblAppoin__Patie__44FF419A");
            });

            modelBuilder.Entity<TblDoctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__TblDocto__2DC00EBF84A467FF");

                entity.Property(e => e.DoctorContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorDateofBirth).HasColumnType("date");

                entity.Property(e => e.DoctorGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorQualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DoctorSpecialization)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.DoctorSpecializationId)
                    .HasConstraintName("FK__TblDoctor__Docto__403A8C7D");
            });

            modelBuilder.Entity<TblLabReport>(entity =>
            {
                entity.HasKey(e => e.LabReportId)
                    .HasName("PK__TblLabRe__971DB70D5F1CA94A");

                entity.Property(e => e.ObservedResult)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__TblLabRep__LogId__75A278F5");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TblLabRep__Patie__73BA3083");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__TblLabRep__Staff__74AE54BC");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__TblLabRep__TestI__76969D2E");
            });

            modelBuilder.Entity<TblMasterLabTest>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__TblMaste__8CC33160291CF070");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NormalRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMasterMedicine>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__TblMaste__4F212890C8B1D82C");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__TblPatie__970EC366F24EDA4C");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPatientLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__TblPatie__5E54864837B9F3E2");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TblPatientLog)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__TblPatien__Appoi__4E88ABD4");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TblPatientLog)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TblPatien__Docto__4D94879B");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblPatientLog)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TblPatien__Patie__4CA06362");
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__TblPayme__9B556A38449BC1A6");

                entity.Property(e => e.Amount)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblPayment)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__TblPaymen__LogId__5FB337D6");
            });

            modelBuilder.Entity<TblPrescriptionMedicine>(entity =>
            {
                entity.HasKey(e => e.PrescriptionMedicineId)
                    .HasName("PK__TblPresc__2C5AC236EA4FA83A");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblPrescriptionMedicine)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__TblPrescr__LogId__5165187F");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.TblPrescriptionMedicine)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__TblPrescr__Medic__52593CB8");
            });

            modelBuilder.Entity<TblPrescriptionTest>(entity =>
            {
                entity.HasKey(e => e.PrescriptionTestId)
                    .HasName("PK__TblPresc__0554749055B613EB");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblPrescriptionTest)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__TblPrescr__LogId__6FE99F9F");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TblPrescriptionTest)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__TblPrescr__TestI__70DDC3D8");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__TblRole__8AFACE1A1749BC11");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSpecialization>(entity =>
            {
                entity.HasKey(e => e.SpecializationId)
                    .HasName("PK__TblSpeci__5809D86F790FE33A");

                entity.Property(e => e.SpecializationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__TblStaff__96D4AB17325A9675");

                entity.Property(e => e.StaffContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDateofBirth).HasColumnType("date");

                entity.Property(e => e.StaffGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblStaff)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__TblStaff__RoleId__3B75D760");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUser__1788CC4C96963063");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__TblUser__RoleId__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
