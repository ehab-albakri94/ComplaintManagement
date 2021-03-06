using ComplaintsManagement.Domain;
using ComplaintsManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsManagement.WebHost.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Complaint> Complaints { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
