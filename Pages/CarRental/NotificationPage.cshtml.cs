using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalWeb.Pages.CarRental
{
    public class NotificationPageModel : PageModel
    {
        public string NotificationMessage { get; set; }
        public void OnGet()
        {
            var mess = TempData["NotificationMessage"];

            try
            {
                NotificationMessage = JsonSerializer.Deserialize<string>((string)mess);
            }
            catch
            {
                NotificationMessage = "Invalid data";
            }
        }
    }
}
