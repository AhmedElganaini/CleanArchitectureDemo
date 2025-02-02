using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : AsyncCrudAppService<Product,int, ProductDto, CreateProductDto, UpdateProducDto>, IProductService
    {
        public ProductService(IRepository<Product,int> productRepository, IMapper mapper) : base(productRepository, mapper)
        {
        }

        public async Task<ProductDto> GetProductByIdAsync(EntityDto<int> productEntity)
        {
            Product product = await _repository.GetAsync(productEntity.Id);
            return MapToEntityDto(product);
        }
    }
}

