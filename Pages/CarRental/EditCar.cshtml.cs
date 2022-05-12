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
    [Authorize(Policy = "AdminOnly")]
    public class EditCarModel : PageModel
    {
        [BindProperty]
        public Car carView { get; set; }
        [BindProperty]
        public City city { get; set; }
        public IEnumerable<City> cities { get; set; }
        private readonly ICarService _carService;
        private readonly ICityService _cityService;
        public EditCarModel(ICarService carService, ICityService cityService)
        {
            _carService = carService;
            _cityService = cityService;
        }
        public ActionResult OnGet(int id)
        {
            if(id != 0)
            {
                carView = _carService.GetCar(id);

                cities = _cityService.GetAllCities();
                return Page();
            }
            return RedirectToPage("Cars");
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(id is 0)
            {
                return RedirectToPage("Cars");
            }

            await _carService.UpdateCar(id, carView, city);

            return RedirectToPage("Cars");
        }
    }
}
