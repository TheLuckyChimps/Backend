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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<Transaction> dbSet;

        public TransactionRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Transaction>();
        }

        public async Task<Transaction> InsertAsync(Transaction transaction, Guid userId)
        {
            transaction.OnCreate(userId);
            var addedStation = (await dbSet.AddAsync(transaction)).Entity;
            await context.SaveChangesAsync();

            return addedStation;
        }
    }
}
