using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebProject.Model;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Services
{
    public class CarService : ICarService
    {
        private readonly AuthDbContext _context;
        public CarService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task CreateNewCar(Car car, City city)
        {
            var SelectedCity = _context.cities.FirstOrDefault(c => c.Id == city.Id);

            var CreatedCar = new Car()
            {
                Name = car.Name,
                Model = car.Model,
                Price = car.Price,
                City = SelectedCity
            };

            await _context.cars.AddAsync(CreatedCar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(int id)
        {
            var carView = await _context.cars.FindAsync(id);

            if (carView != null)
            {
                _context.cars.Remove(carView);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCar(int id, Car car, City city)
        {
            var currentCar = await _context.cars.FindAsync(id);

            var SelectedCity = _context.cities.FirstOrDefault(c => c.Id == city.Id);

            currentCar.Name = car.Name;
            currentCar.Model = car.Model;
            currentCar.Price = car.Price;
            currentCar.City = car.City;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<Car> GetAllCars()
        {
            var cars = _context.cars
                .Include(c => c.City)
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Model)
                .ThenBy(c=>c.City.Name)
                .ToList();

            return cars;
        }

        public async Task RentCar(User user, int id)
        {
            var car = _context.cars.FirstOrDefault(c => c.Id == id);

            var newRent = new User
            {
                Name = user.Name,
                Lastname = user.Lastname,
                PhoneNumber = user.PhoneNumber,
                Car = car,
                DateFrom = user.DateFrom,
                DateTo = user.DateTo,
                TotalCost = Calculate(user.DateFrom, user.DateTo, car.Price)
            };

            await _context.users.AddAsync(newRent);
            await _context.SaveChangesAsync();
        }

        private double Calculate(DateTime StartDate, DateTime EndDate, double cost)
        {
            int timeInterval = (int)Math.Round((EndDate - StartDate).TotalDays);
            var result = cost * timeInterval;
            return result;
        }

        public IEnumerable<Car> GetAvailableCars(DateTime StartDate, DateTime EndDate, string city)
        {
            var listOfAvailableCars = new List<Car>();
            bool isTaken;

            var cars = _context.cars
                .Include(c => c.City)
                .Where(c => c.City.Name == city)
                .ToList();

            var users = _context.users
                .Include(u => u.Car.City)
                .Where(c => c.Car.City.Name == city)
                .ToList();

            foreach (var car in cars)
            {
                isTaken = false;

                var _users = users
                    .Where(u => u.Car.Name == car.Name && u.Car.Model == car.Model)
                    .ToList();

                if (_users.Count() > 0)
                {
                    foreach (var user in _users)
                    {
                        if (StartDate >= user.DateFrom && EndDate <= user.DateTo ||
                             EndDate >= user.DateFrom && EndDate <= user.DateTo ||
                             StartDate >= user.DateFrom && StartDate <= user.DateTo ||
                             StartDate <= user.DateFrom && EndDate >= user.DateTo) //reserved
                        {
                            isTaken = true;
                            break;
                        }
                    }
                }
                if (!isTaken) { listOfAvailableCars.Add(car); }
            }
            return listOfAvailableCars;
        }

        public Car GetCar(int id)
        {
            return _context.cars
                .Include(c => c.City)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
