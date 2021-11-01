using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class PatientMedicalDetail
    {
        public int PatientMedicalDetailsId { get; set; }
        public int PatientAllergyId { get; set; }
        public int DiagnosisId { get; set; }
        public int MedicationId { get; set; }
        public int ProcedureId { get; set; }
        public int PatientVisitId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int PatientId { get; set; }

        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Medication Medication { get; set; }
        public virtual Allergy PatientAllergy { get; set; }
        public virtual PatientVisit PatientVisit { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
