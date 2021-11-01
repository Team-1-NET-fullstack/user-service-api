﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementApI.UserModels
{
    public class AuditModel
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string ObjectName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
