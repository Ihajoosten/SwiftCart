﻿using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
