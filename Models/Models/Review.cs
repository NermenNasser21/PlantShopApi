﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId {  get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
        public int Rate {  get; set; }

    }
}
