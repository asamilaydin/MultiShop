﻿using System;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
    {
        public interface IProductImageService
        {
            Task<List<ResultProductImageDto>> GetAllProductImageAsync();

            Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);

            Task UpdateProductImageAsync(UpdateProductImageDto cProductImageDto);

            Task DeleteProductImageAsync(string id);

            Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);

        }
    }



