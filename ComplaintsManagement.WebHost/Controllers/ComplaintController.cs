 using ComplaintsManagement.Application.DTOs;
using ComplaintsManagement.Domain;
using ComplaintsManagement.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComplaintsManagement.WebHost.Controllers
{
    public class ComplaintController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Complaints()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ComplaintDetails(long id)
        {
            var complaint = new ComplaintDetails
            {
                Id = id
            };
            return View(complaint);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CustomerComplaints()
        {

            return View();
        }
        [Authorize(Roles = "Customer")]
        public IActionResult AddCustomerComplaints()
        {

            return View();
        }
    }
}

