using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalWeb.Notification;
using CarRentalWeb.Notifications;
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
    [AllowAnonymous]
    public class RentCarModel : PageModel
    {
        private readonly ICarService _carService;
        private INotificationSender notificationSender;
        [BindProperty]
        public Car car { get; set; }
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Select notification type")]
        public Notifications notifications { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string selectedCity { get; set; }
        public RentCarModel(ICarService carService)
        {
            _carService = carService;
        }
        public ActionResult OnGet(int id)
        {
            var dateStart = TempData["StartDateAvailableCars"];
            var dateEnd = TempData["EndDateAvailableCars"];
            var City = TempData["SelectedCityAvailableCars"];

            try
            {
                StartDate = JsonSerializer.Deserialize<DateTime>((string)dateStart);
                EndDate = JsonSerializer.Deserialize<DateTime>((string)dateEnd);
                selectedCity = JsonSerializer.Deserialize<string>((string)City);
            }
            catch
            {
                return RedirectToPage("AvailableCars");
            }

            car = _carService.GetCar(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(User user, int id)
        {
            if (id != 0 && user is not null)
            {
                await _carService.RentCar(user, id);

                var car = _carService.GetCar(id);//fix it 

                notificationSender = GetNotificationType(notifications);
                var message = notificationSender.SendNotification(user, car);

                TempData["NotificationMessage"] = JsonSerializer.Serialize(message);

                return RedirectToPage("NotificationPage");
            }
            return Page();
        }

        private INotificationSender GetNotificationType(Notifications notifications)
        {
            switch (notifications)
            {
                case Notifications.SMS:
                    return new SmsNotification();
                case Notifications.PhoneCall:
                    return new PhoneCallNotification();
                default:
                    throw new Exception("Invalid notification type.");
            }
        }
        
    }
}
