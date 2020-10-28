using FirstWebApp.Data.Interfaces;
using FirstWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car>
                {
                    new Car { 
                        name = "Tesla",
                        shortDescription = "",
                        longDescription = "",
                        img = "",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        name = "BMW X5",
                        shortDescription = "",
                        longDescription = "",
                        img = "",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
