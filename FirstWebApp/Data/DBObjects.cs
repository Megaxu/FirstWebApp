using FirstWebApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange( 
                    new Car
                    {
                        name = "Tesla Model-S",
                        shortDescription = "",
                        longDescription = "",
                        img = "/img/Model-S.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "BMW X5",
                        shortDescription = "",
                        longDescription = "",
                        img = "/img/BMW-X5.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Электромобили", description = "Современный вид транспорта"},
                        new Category { categoryName = "Классические автомобили", description = "Машина с двигателем внутреннего сгорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category element in list)
                    {
                        category.Add(element.categoryName, element);
                    }
                }

                return category;
            }
        }
    }
}
