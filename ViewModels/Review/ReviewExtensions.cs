using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class ReviewExtensions
    {
        public static Review ToModel(this AddReviewViewModel model)
        {

            return new Review
            {
                PlantId =model.PlantId,
                ToolId = model.ToolId,
                Rate = model.Rate,
                Comment = model.Comment,
                UserId = model.UserId


            };
        }
    }
}
