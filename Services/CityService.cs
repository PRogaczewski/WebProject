using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Model;
using CarRentalWebProject.Models;

namespace CarRentalWeb.Services
{
    public class CityService : ICityService
    {
        private readonly AuthDbContext _context;
        public CityService(AuthDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.cities.ToList();
        }
    }
}
