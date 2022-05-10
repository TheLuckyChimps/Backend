using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;
using TPL.Database;
using TPL.Repository.Interfaces;

namespace TPL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<Product> dbSet;

        public ProductRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Product>();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var product = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return product;
        }

        public async Task<Product> InsertAsync(Product product, Guid userId)
        {
            product.OnCreate(userId);
            var addedStation = (await dbSet.AddAsync(product)).Entity;
            await context.SaveChangesAsync();

            return addedStation;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var product = await dbSet.FindAsync(id);
            product.SoftDelete();
            await context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<Product> UpdateAsync(Product productUpdate)
        {
            dbSet.Update(productUpdate);
            await context.SaveChangesAsync();

            return productUpdate;
        }
    }
}
