﻿using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<IEnumerable<Brand?>?> GetPopularBrandsAsync(int count);
    }
}
