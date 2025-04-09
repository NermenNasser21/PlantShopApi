using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId {  get; set; }
        public virtual User User {  get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string? Comment { get; set; }
        public int? Rate {  get; set; }

    }
}
