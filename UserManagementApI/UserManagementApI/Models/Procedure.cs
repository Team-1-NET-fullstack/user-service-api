using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class Procedure
    {
        public Procedure()
        {
            PatientMedicalDetails = new HashSet<PatientMedicalDetail>();
        }

        public int ProcedureId { get; set; }
        public int ProcedureMasterId { get; set; }
        public int PatientVisitId { get; set; }
        public bool IsDeprecated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ProcedureDescription { get; set; }
        public int PatientId { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PatientVisit PatientVisit { get; set; }
        public virtual ProcedureMaster ProcedureMaster { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<PatientMedicalDetail> PatientMedicalDetails { get; set; }
    }
}
