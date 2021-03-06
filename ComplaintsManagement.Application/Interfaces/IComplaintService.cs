using ComplaintsManagement.Application.DTOs;
using ComplaintsManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintsManagement.Application.Interfaces
{
    public interface IComplaintService
    {
        Task<string> AddComlaint(AddComplaintDto complaint);
        Task<List<ComplaintDto>> GetComplaints();
        Task<List<CustomerComplaintDto>> GetCutomerComplaints();
        Task<int> GetNumberOfPendingComplaints();
        Task<int> GetNumberOfComplaints();
        Task<int> GetNumberOfResolvedComplaints();
        Task<int> GetNumberOfUrgentComplaints();
        Task<ComplaintDto> GetComplaintById(long id);
        Task ChangeStatusComplaint (long id,int status);
    }
}
