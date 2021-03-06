using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsManagement.Application.DTOs
{
    public class CustomerComplaintDto
    {
        public long ComplaintId { get; set; }
        public string Status { get; set; }
        public DateTime ComplaintTime { get; set; }
        public string IsUrgent { get; set; }
        public string ComplaintType { get; set; }
        public string ComplaintDetails { get; set; }
    }
}
