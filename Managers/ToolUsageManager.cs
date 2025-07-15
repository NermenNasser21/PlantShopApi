using InfraStructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Managers
{
    public class ToolUsageManager : MainManager<ToolUsage>
    {
        public ToolUsageManager(PlantContext _context) : base(_context)
        {
            
        }
    }

        
}
