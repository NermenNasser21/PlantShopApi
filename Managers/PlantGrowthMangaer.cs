using InfraStructure;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class PlantGrowthMangaer : MainManager<PlantGrowth>
    {
        public PlantGrowthMangaer(PlantContext _context) : base(_context)
        {

        }
    }
}
