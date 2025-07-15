using InfraStructure;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class CartProductManager : MainManager<CartProduct>
    {
        public CartProductManager(PlantContext _context) : base(_context) { }
    }
}
