using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Models;

namespace CarRentalWeb.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
    }
}
