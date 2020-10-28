using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBConnect;

        public ShopCart(AppDBContent appDBConnect)
        {
            this.appDBConnect = appDBConnect;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context)
            {
                ShopCartId = shopCartId
            };
        }

        public void AddToCart(Car car)
        {
            this.appDBConnect.ShopCartItem.Add(new ShopCartItem
            {
                shopCartId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBConnect.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDBConnect.ShopCartItem.Where(c => c.shopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
