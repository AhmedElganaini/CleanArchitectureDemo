﻿using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService : IAsyncCrudAppService<int, ProductDto, CreateProductDto, UpdateProducDto>
    {
        Task<ProductDto> GetProductByIdAsync(EntityDto<int> productEntity);

    }
}
