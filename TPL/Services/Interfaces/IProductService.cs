using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.ProductDtos;

namespace TPL.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductResponseDto> CreateProduct(ProductCreateDto product);
        public Task<List<ProductResponseDto>> GetAllProducts();
        public Task<ProductResponseDto> GetProductById(Guid id);
        public Task<ProductResponseDto> DeleteProduct(Guid id);

    }
}
