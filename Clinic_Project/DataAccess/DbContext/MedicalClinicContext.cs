using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.patientAgg;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Project.DataAccess.DbContext;

public partial class MedicalClinicContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MedicalClinicContext()
    {
    }

    public MedicalClinicContext(DbContextOptions<MedicalClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Family).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Skill).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctors_Skills");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Family).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Doctor).WithMany(p => p.Turns)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turns_Doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.Turns)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Turns_Patients");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
