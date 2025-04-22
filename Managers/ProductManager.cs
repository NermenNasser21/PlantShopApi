using InfraStructure;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class ProductManager : MainManager<Product>
    {
        public ProductManager(PlantContext _context) : base(_context)
        {
        }
    }
}
