using FirstWebApp.Data.Interfaces;
using FirstWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромобили", description = "Современный вид транспорта"},
                    new Category { categoryName = "Классические автомобили", description = "Машина с двигателем внутреннего сгорания"}
                };
            }
        }
    }
}
