using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalWebProject.Model;
using CarRentalWebProject.Services;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Pages.CarRental
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateCarModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly ICityService _cityService;
        [BindProperty]
        public Car car { get; set; }
        [BindProperty]
        public City city { get; set; }
        public IEnumerable<City> cities { get; set; }
        public CreateCarModel(ICarService carService, ICityService cityService)
        {
            _carService = carService;
            _cityService = cityService;
        }
        public void OnGet()
        {
            cities = _cityService.GetAllCities();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (car is null)
            {
                return Page();
            }
            await _carService.CreateNewCar(car, city);

            return RedirectToPage("Cars");
        }
    }
}
