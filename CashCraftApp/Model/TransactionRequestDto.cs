using System;
using Microsoft.EntityFrameworkCore;

namespace CashCraftApp.Model
{
	public class TransactionRequestDto
	{
		public TransactionRequestDto()
		{
		}
        public TranType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public required string TransactionSourceAccount { get; set; }
        public required string TransactionDestinationAccount { get; set; }
        [Precision(18, 2)]
        public required decimal TransactionAmount { get; set; }
    }
}

