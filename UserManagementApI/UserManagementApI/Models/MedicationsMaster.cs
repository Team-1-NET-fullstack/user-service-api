using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class MedicationsMaster
    {
        public MedicationsMaster()
        {
            MedicationMedicationMasters = new HashSet<Medication>();
        }

        public int MedicationMastersId { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Description { get; set; }
        public bool IsDeprecated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual Medication MedicationMedicationNavigation { get; set; }
        public virtual ICollection<Medication> MedicationMedicationMasters { get; set; }
    }
}
