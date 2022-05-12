using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetAvailableCars(DateTime StartDate, DateTime EndDate, string city);
        Task CreateNewCar(Car car, City city);
        Task DeleteCar(int id);
        Task UpdateCar(int id, Car car, City city);
        Task RentCar(User user, int id);
        Car GetCar(int id);
    }
}
