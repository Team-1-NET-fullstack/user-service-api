using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class AllergyMaster
    {
        public AllergyMaster()
        {
            Allergies = new HashSet<Allergy>();
        }

        public int AllergyMastersId { get; set; }
        public string Description { get; set; }
        public bool IsFatal { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
    }
}
