using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos.TransactionDtos
{
    public class TransactionResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
