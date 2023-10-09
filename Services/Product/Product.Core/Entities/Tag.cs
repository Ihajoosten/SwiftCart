using Product.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Entities
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }

        // Navigation property
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
