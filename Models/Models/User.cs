using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User 
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart {  get; set; }


    }
}
