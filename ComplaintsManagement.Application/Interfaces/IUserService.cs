using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintsManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<int> GetNumberOfCustomer();
    }
}
