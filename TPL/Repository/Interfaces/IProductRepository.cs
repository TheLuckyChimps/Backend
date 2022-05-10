using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> InsertAsync(Product Station, Guid userId);
        Task<List<Product>> GetAllAsync();
        Task<Guid> DeleteAsync(Guid id);
        Task<Product> UpdateAsync(Product StationUpdate);
        Task<Product> GetByIdAsync(Guid id);
    }
}
