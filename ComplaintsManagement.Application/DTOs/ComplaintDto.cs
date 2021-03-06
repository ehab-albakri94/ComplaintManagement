using ComplaintsManagement.Domain.Enums;
using ComplaintsManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComplaintsManagement.Application.DTOs
{
    public class ComplaintDto
    {
     
        public long ComplaintId { get; set; }
        public string Status { get; set; }
        public DateTime ComplaintTime { get; set; }
        public string IsUrgent { get; set; }
        public string ComplaintType { get; set; }
        public string ComplaintDetails { get; set; }
        public string UserId { get; set; }
        public string CutomerEmail { get; set; }
        public string CustomerName { get; set; }
    }
}
