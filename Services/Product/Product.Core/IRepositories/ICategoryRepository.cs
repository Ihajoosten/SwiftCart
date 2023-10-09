using Product.Core.Entities;
using Product.Core.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category?>?> GetMainCategoriesAsync();
    }
}
