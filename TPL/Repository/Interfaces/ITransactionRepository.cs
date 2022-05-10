using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<Transaction> InsertAsync(Transaction transaction, Guid userId);
    }
}
