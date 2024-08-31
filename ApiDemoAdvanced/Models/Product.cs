﻿using System;
namespace ApiDemoAdvanced.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } // Used in V2
    }
}

