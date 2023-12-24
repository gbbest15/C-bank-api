using System;
using Microsoft.EntityFrameworkCore;

namespace CashCraftApp.Model
{
	public class GetAccountModel
	{
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string Lastname { get; set; }
        public required string AccountName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string AccountNumber { get; set; }
        [Precision(18, 2)]
        public required decimal CurrentAccountBalance { get; set; }
        public required DateTime DateCreated { get; set; }
        public required DateTime LastUpdated { get; set; }

    }
}

