using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class DiagnosisMaster
    {
        public DiagnosisMaster()
        {
            Diagnoses = new HashSet<Diagnosis>();
        }

        public int DiagnosisMastersId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
