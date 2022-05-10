using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.ProductDtos;
using TPL.Data.Dtos.TransactionDtos;

namespace TPL.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductResponseDto> CreateProduct(ProductCreateDto product);
        public Task<List<ProductResponseDto>> GetAllProducts();
        public Task<ProductResponseDto> GetProductById(Guid id);
        public Task<ProductResponseDto> DeleteProduct(Guid id);
        Task<TransactionResponseDto> CreateTransaction(Guid id);

    }
}
