using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Models;

namespace CarRentalWeb.Notifications
{
    public interface INotificationSender
    {
        string SendNotification(User user, Car car);
    }
}
