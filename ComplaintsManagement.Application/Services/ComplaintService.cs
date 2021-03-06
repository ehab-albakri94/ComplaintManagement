using AutoMapper;
using ComplaintsManagement.Application.DTOs;
using ComplaintsManagement.Application.Interfaces;
using ComplaintsManagement.Domain;
using ComplaintsManagement.Domain.Enums;
using ComplaintsManagement.Domain.Models;
using ComplaintsManagement.WebHost.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintsManagement.Application.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ComplaintService(UserManager<User> userManager
            , ApplicationDbContext dbContext
            ,IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        // add customer complaint  
        public async Task<string> AddComlaint(AddComplaintDto complaintDto)
        {
            try
            {
                
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (string.IsNullOrEmpty(userId))
                    return "Invalid user id";
                Complaint complaint = new Complaint
                {

                    UserId = userId,
                    ComplaintDetails = complaintDto.ComplaintDetails,
                    ComplaintTime = DateTime.Now,
                    ComplaintType = complaintDto.ComplaintType,
                    IsUrgent = complaintDto.IsUrgent,
                    Status = Status.pending
                };
                await _dbContext.AddAsync(complaint);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // get all complaints for admin
        public async Task<List<ComplaintDto>> GetComplaints()
        {
            try
            {
                var query = await _dbContext.Complaints.Include(c=>c.User).ToListAsync();
                var complaints = _mapper.Map<List<ComplaintDto>>(query);
                return complaints;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get All customer complaints
        public async Task<List<CustomerComplaintDto>> GetCutomerComplaints()
        {
            try
            {
                //get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("Invalid user id");
                var query = await _dbContext.Complaints.Where(c=>c.UserId==userId).ToListAsync();
                var complaints = _mapper.Map<List<CustomerComplaintDto>>(query);
                return complaints;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        //retrieve number of all complaints
        public async Task<int> GetNumberOfComplaints()
        {
            try
            {
                var complaints = await _dbContext.Complaints.CountAsync();
               
                return complaints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //retrieve number of all resolved complaints
        public async Task<int> GetNumberOfResolvedComplaints()
        {
            try
            {
                var complaints = await _dbContext.Complaints.Where(c=>c.Status== Status.resolved).CountAsync();

                return complaints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //retrieve number of all pending complaints
        public async Task<int> GetNumberOfPendingComplaints()
        {
            try
            {
                var complaints = await _dbContext.Complaints.Where(c => c.Status == Status.pending).CountAsync();

                return complaints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //retrieve number of all Urgent complaints
        public async Task<int> GetNumberOfUrgentComplaints()
        {
            try
            {
                var complaints = await _dbContext.Complaints.Where(c => c.IsUrgent == true).CountAsync();

                return complaints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ComplaintDto> GetComplaintById(long id)
        {
            try
            {
                var query = await _dbContext.Complaints.Include(c => c.User).Where(c => c.ComplaintId == id).FirstOrDefaultAsync();
                var complaint = _mapper.Map<ComplaintDto>(query);
                return complaint;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ChangeStatusComplaint(long id,int status)// pass enum status
        {
            try
            {
                var complaint = await _dbContext.Complaints.Where(c => c.ComplaintId == id).FirstOrDefaultAsync();
                complaint.Status = (Status)status;
                _dbContext.Complaints.Update(complaint);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
