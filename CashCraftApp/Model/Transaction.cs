using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CashCraftApp.Model
{
    [Table("Transactions")]
    public class Transaction
	{
		public Transaction()
		{
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 17)}";
        }

        [Key]
        public int Id { get; set; }
        public required string TransactionUniqueReference { get; set; }
        [Precision(18, 2)]
        public required decimal TransactionAmount { get; set; }
        public TranStatus TransactionStatus { get; set; }
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Success);
        public required string TransactionSourceAccount { get; set; }
        public required string TransactionDestinationAccount { get; set; }
        public required string TransactionParticulars { get; set; }
        public TranType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public enum TranStatus
    {
        Failed,
        Success,
        Error
    }

    public enum TranType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}

