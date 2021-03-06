using ComplaintsManagement.Application.Interfaces;
using ComplaintsManagement.Domain.Models;
using ComplaintsManagement.WebHost.Data; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintsManagement.Application.Services
{
    public class UserService : IUserService
    {
        

        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
          
            _dbContext = dbContext;
        }
        public async Task<int> GetNumberOfCustomer()
        {
            try
            {
                var customerRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Customer");// get custmer role
                var numberOfCustomer = await _dbContext.Set<IdentityUserRole<string>>().CountAsync(r => r.RoleId == customerRole.Id); // get number of customers
                return numberOfCustomer;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
