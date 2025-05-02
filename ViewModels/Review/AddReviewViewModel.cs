using Models.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class AddReviewViewModel
    {
        public string? UserId { get; set; }
        public int? PlantId { get; set; }
        public int? ToolId { get; set; }
        public string? Comment { get; set; }
        public int? Rate { get; set; }

    }
}
