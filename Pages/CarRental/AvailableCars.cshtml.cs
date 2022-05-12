using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalWebProject.Model;
using CarRentalWebProject.Services;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Pages.CarRental
{
    public class AvailableCars : PageModel
    {
        private readonly ICarService _carService;
        [BindProperty]
        public IEnumerable<Car> availableCars { get; set; }
        [BindProperty]
        public User user { get; set; }
        public City city { get; set; }
        private static string _selectedCity { get; set; }
        [BindProperty]
        [Required]
        [DisplayFormat(DataFormatString = "dd-MM-yy", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [BindProperty]
        [Required]
        [DisplayFormat(DataFormatString = "dd-MM-yy", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public AvailableCars(ICarService carService)
        {
            _carService = carService;
        }
        public void OnGet()
        {
            var dateStart = TempData["StartDate"];
            var dateEnd = TempData["EndDate"];
            var City = TempData["SelectedCity"];

            try
            {
                StartDate = JsonSerializer.Deserialize<DateTime>((string)dateStart);
                EndDate = JsonSerializer.Deserialize<DateTime>((string)dateEnd);
                city = JsonSerializer.Deserialize<City>((string)City);
                _selectedCity = city.Name;
            }
            catch
            {
                StartDate = DateTime.Now;
                EndDate = StartDate.AddDays(1);
            }

            availableCars = _carService.GetAvailableCars(StartDate, EndDate, _selectedCity);

            SerializeDates();
        }

        public ActionResult OnPost()
        {
            availableCars = _carService.GetAvailableCars(StartDate, EndDate, _selectedCity);

            SerializeDates();

            return Page();
        }

        public ActionResult OnPostRent(int id)
        {
            TempData["SelectedCityAvailableCars"] = JsonSerializer.Serialize(_selectedCity);
            return Redirect($"/CarRental/RentCar?id={id}");
        }

        private void SerializeDates()
        {
            TempData["StartDateAvailableCars"] = JsonSerializer.Serialize(StartDate);
            TempData["EndDateAvailableCars"] = JsonSerializer.Serialize(EndDate);
        }
    }
}
