﻿using System.Collections;
using System.Collections.Generic;

namespace Testing.Models.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}