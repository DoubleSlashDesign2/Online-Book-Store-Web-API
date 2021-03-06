﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
    public class CartView
    {
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
        public string BookImageUrl { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
          
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public double? Rating { get; set; }
        public string Description { get; set; }
       


    }
}
