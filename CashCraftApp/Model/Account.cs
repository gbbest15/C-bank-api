using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CashCraftApp.Model
{
    [Table("Account")]
    public class Account
    {
        Random rnd = new Random();
        

        public Account()
        {
            double result = rnd.NextDouble() * 9_000_000_000L * 1_000_000_000L;
            AccountNumber = result.ToString();
            AccountName = $"{FirstName} {Lastname}";
        }

        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string Lastname { get; set; }
        public required string AccountName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        [Precision(18, 2)]
        public required decimal CurrentAccountBalance { get; set; }
        public AccountType AccountType {get; set;}
        public required string AccountNumber { get; set; }
        public byte[]? PinHash { get; set; }
        public byte[]? PinSalt { get; set; }
        public required DateTime DateCreated { get; set; }
        public required DateTime LastUpdated { get; set; }
    }


    public enum AccountType
    {
        saving,
        current,
        cooperate,
        government
    }

}

