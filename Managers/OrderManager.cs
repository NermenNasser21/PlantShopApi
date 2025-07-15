using InfraStructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Managers
{
    public class OrderManager : MainManager<Order>
    {
        private CartManager cartManager;
        public OrderManager(PlantContext _context,CartManager _cartManager) : base(_context)
        {
            cartManager = _cartManager;
        }

        public async Task<bool> Add(AddOrderViewModel model)
        {
            Order Order = model.ToModel();
            Cart cart = await cartManager.GetOne(model.CartId);
            var cartProducts = cart.Products.Where(p=>p.selected == true).ToList();


            foreach (var product in cartProducts) 
            {
                Order.Products.Add(new OrderedProduct()
                {
                    PlantId = product.PlantId,
                    ToolId = product.ToolId,
                    Quantity = product.Quantity

                });

            }
            var res = await base.Add(Order);
            return res;

        }

        
    }
}
