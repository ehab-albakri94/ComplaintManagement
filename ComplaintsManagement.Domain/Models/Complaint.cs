using ComplaintsManagement.Domain.Enums;
using ComplaintsManagement.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComplaintsManagement.Domain
{
    public class Complaint
    { 
       
        public long ComplaintId { get; set; }
        public Status Status { get; set; }
        public DateTime ComplaintTime { get; set; }
        public string ComplaintType { get; set; }
        public bool IsUrgent { get; set; }
        public string ComplaintDetails { get; set; }
        public string UserId { get; set; }
        public User User  { get; set; }
    }
}
