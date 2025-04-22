using InfraStructure;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class CategoryManager : MainManager<Category>
    {
        public CategoryManager(PlantContext _context) : base(_context) { }
    }
}
