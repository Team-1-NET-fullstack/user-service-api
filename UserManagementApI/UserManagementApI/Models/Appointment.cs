using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementApI.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public string Reason { get; set; }
        public int? TimeSlot { get; set; }
        public int Duration { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual User Physician { get; set; }
        public virtual TimeSlot TimeSlotNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
    }
}
