using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class Medication
    {
        public Medication()
        {
            PatientMedicalDetails = new HashSet<PatientMedicalDetail>();
        }

        public int MedicationId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string MedicationDescription { get; set; }
        public int MedicationMasterId { get; set; }
        public int PatientId { get; set; }
        public int PatientVisitId { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual MedicationsMaster MedicationMaster { get; set; }
        public virtual MedicationsMaster MedicationNavigation { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PatientVisit PatientVisit { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<PatientMedicalDetail> PatientMedicalDetails { get; set; }
    }
}
