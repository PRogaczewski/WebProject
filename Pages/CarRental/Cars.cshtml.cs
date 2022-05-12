using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalWebProject.Model;
using CarRentalWebProject.Services;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Pages.CarRental
{
    public class CarsModel : PageModel
    {
        public IEnumerable<Car> cars;
        private readonly ICarService _carService;
        public CarsModel(ICarService carService)
        {
            _carService = carService;
        }
        public void OnGet()
        {
            cars = _carService.GetAllCars();
        }
    }
}
