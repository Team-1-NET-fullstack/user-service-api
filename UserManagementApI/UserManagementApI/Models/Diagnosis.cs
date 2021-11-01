using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            PatientMedicalDetails = new HashSet<PatientMedicalDetail>();
        }

        public int DiagnosisId { get; set; }
        public int DiagnosisMasterId { get; set; }
        public int PatientVisitId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PatientId { get; set; }
        public string DignosisDescription { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual DiagnosisMaster DiagnosisMaster { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PatientVisit PatientVisit { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<PatientMedicalDetail> PatientMedicalDetails { get; set; }
    }
}
