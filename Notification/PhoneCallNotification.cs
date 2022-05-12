using CarRentalWeb.Notification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Models;

namespace CarRentalWeb.Notifications
{
    public class PhoneCallNotification : INotificationSender
    {
        public string SendNotification(User user, Car car)
        {
            var template = File.ReadAllText(@"E:\CS\WEB\Test\CarRentalWeb\Notification\PhoneCallNotification.txt");
            var document = template.Replace("{username}", user.Name + " " + user.Lastname).Replace("{carname}", car.Name).Replace("{carmodel}", car.Model).Replace("{dateStart}", user.DateFrom.ToString("d"));
            return document;
        }
    }
}
