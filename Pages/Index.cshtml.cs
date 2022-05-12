using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Models;
using System.Text.Json;
using CarRentalWebProject.Model;
using System.ComponentModel.DataAnnotations;

namespace CarRentalWebProject.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public Car car { get; set; }
        [BindProperty]
        [Required]
        public City city { get; set; }
        public IEnumerable<City> cities { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly AuthDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AuthDbContext context) 
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
            cities = _context.cities.ToList();
        }
        public ActionResult OnPost()
        {
            DateTime StartDate = user.DateFrom;
            DateTime EndDate = user.DateTo;
            var SelectedCity = _context.cities.FirstOrDefault(c => c.Id == city.Id);

            TempData["StartDate"] = JsonSerializer.Serialize(StartDate);
            TempData["EndDate"] = JsonSerializer.Serialize(EndDate);
            TempData["SelectedCity"] = JsonSerializer.Serialize(SelectedCity);

            return RedirectToPage("/CarRental/AvailableCars");
        }
    }
}
