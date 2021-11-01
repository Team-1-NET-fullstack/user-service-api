using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class User
    {
        public User()
        {
            AllergyCreatedByNavigations = new HashSet<Allergy>();
            AllergyMasterCreatedByNavigations = new HashSet<AllergyMaster>();
            AllergyMasterUpdatedByNavigations = new HashSet<AllergyMaster>();
            AllergyUpdatedByNavigations = new HashSet<Allergy>();
            AppointmentCreatedByNavigations = new HashSet<Appointment>();
            AppointmentPhysicians = new HashSet<Appointment>();
            AppointmentUpdatedByNavigations = new HashSet<Appointment>();
            DiagnosisCreatedByNavigations = new HashSet<Diagnosis>();
            DiagnosisMasterCreatedByNavigations = new HashSet<DiagnosisMaster>();
            DiagnosisMasterUpdatedByNavigations = new HashSet<DiagnosisMaster>();
            DiagnosisUpdatedByNavigations = new HashSet<Diagnosis>();
            MedicationCreatedByNavigations = new HashSet<Medication>();
            MedicationUpdatedByNavigations = new HashSet<Medication>();
            MedicationsMasterCreatedByNavigations = new HashSet<MedicationsMaster>();
            MedicationsMasterUpdatedByNavigations = new HashSet<MedicationsMaster>();
            NoteCreatedByNavigations = new HashSet<Note>();
            NoteReceiverNavigations = new HashSet<Note>();
            NoteSenderNavigations = new HashSet<Note>();
            NoteUpdatedByNavigations = new HashSet<Note>();
            PatientCreatedByNavigations = new HashSet<Patient>();
            PatientUpdatedByNavigations = new HashSet<Patient>();
            PatientVisitCreatedByNavigations = new HashSet<PatientVisit>();
            PatientVisitPhysicians = new HashSet<PatientVisit>();
            PatientVisitUpdatedByNavigations = new HashSet<PatientVisit>();
            PatientsNomineeCreatedByNavigations = new HashSet<PatientsNominee>();
            PatientsNomineeUpdatedByNavigations = new HashSet<PatientsNominee>();
            ProcedureCreatedByNavigations = new HashSet<Procedure>();
            ProcedureMasterCreatedByNavigations = new HashSet<ProcedureMaster>();
            ProcedureMasterUpdatedByNavigations = new HashSet<ProcedureMaster>();
            ProcedureUpdatedByNavigations = new HashSet<Procedure>();
        }

        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime Dob { get; set; }
        public string EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsFirstTimeUser { get; set; }
        public int? WorngAttempts { get; set; }
        public long? ContactNo { get; set; }
        public string Gender { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Allergy> AllergyCreatedByNavigations { get; set; }
        public virtual ICollection<AllergyMaster> AllergyMasterCreatedByNavigations { get; set; }
        public virtual ICollection<AllergyMaster> AllergyMasterUpdatedByNavigations { get; set; }
        public virtual ICollection<Allergy> AllergyUpdatedByNavigations { get; set; }
        public virtual ICollection<Appointment> AppointmentCreatedByNavigations { get; set; }
        public virtual ICollection<Appointment> AppointmentPhysicians { get; set; }
        public virtual ICollection<Appointment> AppointmentUpdatedByNavigations { get; set; }
        public virtual ICollection<Diagnosis> DiagnosisCreatedByNavigations { get; set; }
        public virtual ICollection<DiagnosisMaster> DiagnosisMasterCreatedByNavigations { get; set; }
        public virtual ICollection<DiagnosisMaster> DiagnosisMasterUpdatedByNavigations { get; set; }
        public virtual ICollection<Diagnosis> DiagnosisUpdatedByNavigations { get; set; }
        public virtual ICollection<Medication> MedicationCreatedByNavigations { get; set; }
        public virtual ICollection<Medication> MedicationUpdatedByNavigations { get; set; }
        public virtual ICollection<MedicationsMaster> MedicationsMasterCreatedByNavigations { get; set; }
        public virtual ICollection<MedicationsMaster> MedicationsMasterUpdatedByNavigations { get; set; }
        public virtual ICollection<Note> NoteCreatedByNavigations { get; set; }
        public virtual ICollection<Note> NoteReceiverNavigations { get; set; }
        public virtual ICollection<Note> NoteSenderNavigations { get; set; }
        public virtual ICollection<Note> NoteUpdatedByNavigations { get; set; }
        public virtual ICollection<Patient> PatientCreatedByNavigations { get; set; }
        public virtual ICollection<Patient> PatientUpdatedByNavigations { get; set; }
        public virtual ICollection<PatientVisit> PatientVisitCreatedByNavigations { get; set; }
        public virtual ICollection<PatientVisit> PatientVisitPhysicians { get; set; }
        public virtual ICollection<PatientVisit> PatientVisitUpdatedByNavigations { get; set; }
        public virtual ICollection<PatientsNominee> PatientsNomineeCreatedByNavigations { get; set; }
        public virtual ICollection<PatientsNominee> PatientsNomineeUpdatedByNavigations { get; set; }
        public virtual ICollection<Procedure> ProcedureCreatedByNavigations { get; set; }
        public virtual ICollection<ProcedureMaster> ProcedureMasterCreatedByNavigations { get; set; }
        public virtual ICollection<ProcedureMaster> ProcedureMasterUpdatedByNavigations { get; set; }
        public virtual ICollection<Procedure> ProcedureUpdatedByNavigations { get; set; }
    }
}
