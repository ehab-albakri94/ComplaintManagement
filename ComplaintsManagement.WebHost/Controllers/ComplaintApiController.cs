using ComplaintsManagement.Application.DTOs;
using ComplaintsManagement.Application.Interfaces;
using ComplaintsManagement.WebHost.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintsManagement.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComplaintApiController : ControllerBase
    {
        readonly IComplaintService _complaintService;
        public ComplaintApiController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }
        //Get All complaints for admin
        [Authorize(Roles = "Admin")]
        [HttpGet("GetComplaints")]
        public async Task<ActionResult<List<ComplaintDto>>> GetComplaints()
        {
            try
            {
                var complaints = await _complaintService.GetComplaints();
                return Ok(complaints);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get All customer complaints
        [Authorize(Roles = "Customer")]
        [HttpGet("GetCustomerComplaints")]
        public async Task<ActionResult<List<CustomerComplaintDto>>> GetCustomerComplaints()
        {
            try
            {
                var complaints = await _complaintService.GetCutomerComplaints();
                return Ok(complaints);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // add complaint from customer
        [Authorize(Roles = "Customer")]
        [HttpPost("AddComplaint")]
        public async Task<ActionResult<string>> AddComplaint(AddComplaintDto addComplaintDto)
        {
            try
            {
                
                    var complaints = await _complaintService.AddComlaint(addComplaintDto);
                    return Ok(complaints);
                
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetNumberOfComplaints")]
        public async Task<ActionResult<string>> GetNumberOfComplaints()
        {
            try
            {
                var complaints = await _complaintService.GetNumberOfComplaints();
                return Ok(complaints);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetNumberOfPendingComplaints")]
        public async Task<ActionResult<string>> GetNumberOfPendingComplaints()
        {
            try
            {
                var pendingComplaints = await _complaintService.GetNumberOfPendingComplaints();
                return Ok(pendingComplaints);
            }
           catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetNumberOfResolvedComplaints")]
        public async Task<ActionResult<string>> GetNumberOfResolvedComplaints()
        {
            try
            {
                var resolvedComplaints = await _complaintService.GetNumberOfResolvedComplaints();
                return Ok(resolvedComplaints);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetNumberOfUrgentComplaints")]
        public async Task<ActionResult<string>> GetNumberOfUrgentComplaints()
        {
            try
            {
                var resolvedComplaints = await _complaintService.GetNumberOfUrgentComplaints();
                return Ok(resolvedComplaints);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [Authorize(Roles = "Admin")]
        [HttpGet("GetComplaintById")]
        public async Task<ActionResult<ComplaintDto>> GetComplaintById(long id)
        {
            try
            {
                var complaint = await _complaintService.GetComplaintById(id);
                return Ok(complaint);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("ChangeStatusComplaint")]
        public async Task<ActionResult> ChangeStatusComplaint(long id,int status)
        {
            try
            {
                 await _complaintService.ChangeStatusComplaint(id,status);
                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
