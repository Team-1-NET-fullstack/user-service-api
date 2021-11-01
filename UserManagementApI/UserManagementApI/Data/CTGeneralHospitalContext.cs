using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserManagementApI.Models;

#nullable disable

namespace UserManagementApI.Data
{
    public partial class CTGeneralHospitalContext : DbContext
    {
        public CTGeneralHospitalContext()
        {
        }

        public CTGeneralHospitalContext(DbContextOptions<CTGeneralHospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergy> Allergies { get; set; }
        public virtual DbSet<AllergyMaster> AllergyMasters { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<DiagnosisMaster> DiagnosisMasters { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<MedicationsMaster> MedicationsMasters { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientMedicalDetail> PatientMedicalDetails { get; set; }
        public virtual DbSet<PatientVisit> PatientVisits { get; set; }
        public virtual DbSet<PatientVital> PatientVitals { get; set; }
        public virtual DbSet<PatientsNominee> PatientsNominees { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<ProcedureMaster> ProcedureMasters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=IMCTBCP47-MSL1\\SQLEXPRESS;initial catalog=CTGeneralHospital;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.HasKey(e => e.PatientAllergyId)
                    .HasName("PK__Allergy__2844413D383E90D5");

                entity.ToTable("Allergy");

                entity.Property(e => e.PatientAllergyId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AllergyMasters)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.AllergyMastersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllergyMasterId");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AllergyCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALCreatedBy");

                entity.HasOne(d => d.PatientVisit)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.PatientVisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APatientVisitId");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AllergyUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALUpdatedBy");
            });

            modelBuilder.Entity<AllergyMaster>(entity =>
            {
                entity.HasKey(e => e.AllergyMastersId)
                    .HasName("PK__AllergyM__915CEE7461D415E4");

                entity.Property(e => e.AllergyMastersId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AllergyMasterCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AMCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AllergyMasterUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AMUpdatedBy");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AppointmentCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACreatedBy");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientId");

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.AppointmentPhysicians)
                    .HasForeignKey(d => d.PhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicianId");

                entity.HasOne(d => d.TimeSlotNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TimeSlot)
                    .HasConstraintName("FK_TimeSlotId");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AppointmentUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUpdatedBy");
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("Diagnosis");

                entity.Property(e => e.DiagnosisId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DignosisDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DiagnosisCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DCreatedBy");

                entity.HasOne(d => d.DiagnosisMaster)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.DiagnosisMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiagnosisMasterId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DPatientId");

                entity.HasOne(d => d.PatientVisit)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.PatientVisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DPatientsVisitsId");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.DiagnosisUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DUpdatedBy");
            });

            modelBuilder.Entity<DiagnosisMaster>(entity =>
            {
                entity.HasKey(e => e.DiagnosisMastersId)
                    .HasName("PK__Diagnosi__06BCD58C09A2F892");

                entity.Property(e => e.DiagnosisMastersId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DiagnosisMasterCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DMCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.DiagnosisMasterUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DMUpdatedBy");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.MedicationId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MedicationDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MedicationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCreatedBy");

                entity.HasOne(d => d.MedicationNavigation)
                    .WithOne(p => p.MedicationMedicationNavigation)
                    .HasForeignKey<Medication>(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicationMasterId");

                entity.HasOne(d => d.MedicationMaster)
                    .WithMany(p => p.MedicationMedicationMasters)
                    .HasForeignKey(d => d.MedicationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MMedicationID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicationsPatientId");

                entity.HasOne(d => d.PatientVisit)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.PatientVisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MPatientsVisits");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MedicationUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MUpdatedBy");
            });

            modelBuilder.Entity<MedicationsMaster>(entity =>
            {
                entity.HasKey(e => e.MedicationMastersId)
                    .HasName("PK__Medicati__867661AE811C4527");

                entity.Property(e => e.MedicationMastersId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MedicationsMasterCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MMCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MedicationsMasterUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MMUpdatedBy");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NoteCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NCreatedBy");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.NoteReceiverNavigations)
                    .HasForeignKey(d => d.Receiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receiver");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.NoteSenderNavigations)
                    .HasForeignKey(d => d.Sender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sender");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.NoteUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NUpdatedBy");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Languages)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreatedBy");

                entity.HasOne(d => d.Nominee)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.NomineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NomineeId");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PatientUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UpdatedBy");
            });

            modelBuilder.Entity<PatientMedicalDetail>(entity =>
            {
                entity.HasKey(e => e.PatientMedicalDetailsId)
                    .HasName("PK__PatientM__CBA3DC534ABF7171");

                entity.Property(e => e.PatientMedicalDetailsId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProcedureId).HasColumnName("ProcedureID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.PatientMedicalDetails)
                    .HasForeignKey(d => d.DiagnosisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiagnosisId");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.PatientMedicalDetails)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicalId");

                entity.HasOne(d => d.PatientAllergy)
                    .WithMany(p => p.PatientMedicalDetails)
                    .HasForeignKey(d => d.PatientAllergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMedicalDetails");

                entity.HasOne(d => d.PatientVisit)
                    .WithMany(p => p.PatientMedicalDetails)
                    .HasForeignKey(d => d.PatientVisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientVisitId");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.PatientMedicalDetails)
                    .HasForeignKey(d => d.ProcedureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureId");
            });

            modelBuilder.Entity<PatientVisit>(entity =>
            {
                entity.Property(e => e.PatientVisitId).ValueGeneratedNever();

                entity.Property(e => e.AllergyDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiagnosisDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MedicationDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedureDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VisitDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientVisitCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PVCreatedBy");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientVisits)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PVPatientId");

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.PatientVisitPhysicians)
                    .HasForeignKey(d => d.PhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientsVisits");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PatientVisitUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PVUpdatedBy");
            });

            modelBuilder.Entity<PatientVital>(entity =>
            {
                entity.Property(e => e.PatientVitalId).ValueGeneratedNever();

                entity.Property(e => e.BloodPressure)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.RespirationRate).HasColumnName("Respiration Rate");

                entity.HasOne(d => d.PatientVisit)
                    .WithMany(p => p.PatientVitals)
                    .HasForeignKey(d => d.PatientVisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientsVitals");
            });

            modelBuilder.Entity<PatientsNominee>(entity =>
            {
                entity.HasKey(e => e.NomineeId);

                entity.ToTable("PatientsNominee");

                entity.Property(e => e.NomineeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NomineeAddress)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Relationship)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientsNomineeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PNCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PatientsNomineeUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PNUpdatedBy");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.Property(e => e.ProcedureId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProcedureDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProcedureCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PCreatedBy");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PPatientId");

                entity.HasOne(d => d.PatientVisit)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.PatientVisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PPatientsVisits");

                entity.HasOne(d => d.ProcedureMaster)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.ProcedureMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureMasterId");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProcedureUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PUpdatedBy");
            });

            modelBuilder.Entity<ProcedureMaster>(entity =>
            {
                entity.HasKey(e => e.ProcedureMastersId)
                    .HasName("PK__Procedur__079352C2C7FC806C");

                entity.Property(e => e.ProcedureMastersId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProcedureMasterCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PMCreatedBy");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProcedureMasterUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PMUpdatedBy");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.Property(e => e.TimeSlotId).ValueGeneratedNever();

                entity.Property(e => e.Slots).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailId, "UQ__Users__7ED91AEE6986BA0B")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleId__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
