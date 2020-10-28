using FirstWebApp.Data.Interfaces;
using FirstWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBConnect;

        public CarRepository(AppDBContent appDBConnect)
        {
            this.appDBConnect = appDBConnect;
        }

        public IEnumerable<Car> Cars => appDBConnect.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDBConnect.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => appDBConnect.Car.FirstOrDefault(predicate => predicate.id == carId);
    }
}
