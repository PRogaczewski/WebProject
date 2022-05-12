using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Model;
using CarRentalWebProject.Models;

namespace CarRentalWeb.Services
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _context;
        public UserService(AuthDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.users
                .Include(x => x.Car)
                .Include(x => x.Car.City)
                .ToList();
        }
    }
}
