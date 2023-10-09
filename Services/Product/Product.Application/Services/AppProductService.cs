﻿using AutoMapper;
using Product.Application.Dto.Product;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppProductService : ApplicationService<Core.Entities.Product, ProductDto, CreateProductDto, UpdateProductDto>, IAppProductService
    {
        private readonly IProductRepository _productRepository;

        public AppProductService(IProductRepository productRepository, IMapper mapper)
            : base(productRepository, mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductDto>> GetTopSellingProductsAsync(int count)
        {
            var products = await _productRepository.GetTopSellingProductsAsync(count);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetNewArrivalProductsAsync(int count)
        {
            var products = await _productRepository.GetNewArrivalProductsAsync(count);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public override async Task<ProductDto> CreateAsync(CreateProductDto createDto)
        {
            createDto.CreatedAt = createDto.CreatedAt == default ? DateTime.UtcNow : createDto.CreatedAt;

            var entity = _mapper.Map<Core.Entities.Product>(createDto);
            entity = await _repository.AddAsync(entity);

            return _mapper.Map<ProductDto>(entity);
        }

        public override async Task UpdateAsync(int id, UpdateProductDto updateDto)
        {
            updateDto.UpdatedAt = updateDto.UpdatedAt == default ? DateTime.UtcNow : updateDto.UpdatedAt;

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return;

            _mapper.Map(updateDto, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
