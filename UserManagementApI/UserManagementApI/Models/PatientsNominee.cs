using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class PatientsNominee
    {
        public PatientsNominee()
        {
            Patients = new HashSet<Patient>();
        }

        public int NomineeId { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Relationship { get; set; }
        public int ContactNumber { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool HasAccess { get; set; }
        public string NomineeAddress { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
