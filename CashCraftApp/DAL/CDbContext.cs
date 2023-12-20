using System;
using CashCraftApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CashCraftApp.DAL
{
	public class CDbContext: DbContext
    {
		public CDbContext(DbContextOptions<CDbContext> options) : base(options)
        {
		}

        public required DbSet<Account> Accounts { get; set; }
        public required DbSet<Transaction> Transactions { get; set; }
    }
}

