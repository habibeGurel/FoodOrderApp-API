﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Application.ViewModels.Products
{
    public class VM_Create_Product
    {
        public string Category { get; set;}
        public string Name { get; set;}
        public int Stock { get; set;}
        public float Price { get; set;}
        

    }
}
