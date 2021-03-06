using ComplaintsManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComplaintsManagement.Application.DTOs
{
    public class AddComplaintDto
    {
        
        [Required]
        public string ComplaintType { get; set; }
        [Required]
        public string ComplaintDetails { get; set; }
        [Required]
        public bool IsUrgent { get; set; }

    }
}
