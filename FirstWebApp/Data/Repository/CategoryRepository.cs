using FirstWebApp.Data.Interfaces;
using FirstWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBConnect;

        public CategoryRepository(AppDBContent appDBConnect)
        {
            this.appDBConnect = appDBConnect;
        }
        public IEnumerable<Category> AllCategories => appDBConnect.Category;
    }
}
