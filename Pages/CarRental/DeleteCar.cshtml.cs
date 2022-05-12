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
    public class DeleteCarModel : PageModel
    {
        [BindProperty]
        public Car carView { get; set; }
        private readonly ICarService _carService;
        public DeleteCarModel(ICarService carService)
        {
            _carService = carService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id is 0)
            {
                return RedirectToPage("Cars");
            }
            await _carService.DeleteCar(id);

            return RedirectToPage("Cars");
        }
    }
}
