using System;
using System.Net.NetworkInformation;
using System.Text;
using CashCraftApp.DAL;
using CashCraftApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CashCraftApp.Services.implementations
{
	public class AccountService : IAccountService
    {
        private CDbContext _db;

        public AccountService(CDbContext db)
		{
            _db = db;
		}

        public Account Authenticate(string AccountNumber, string Pin)
        {
            throw new NotImplementedException();
        }

        public Account Create(Account account, string Pin, string ConfirmPin)
        {
            if (string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException("Pin cannot be empty");
            if (_db.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("A user with this email exists");
            if (!Pin.Equals(ConfirmPin)) throw new ApplicationException("Pins do not match.");

            byte[] pinHash, pinSalt;

            createHashingPassword(Pin, out pinHash, out pinSalt);

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            _db.Accounts.Add(account);
            _db.SaveChanges();

            return account;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public Account GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account, string? Pin)
        {
            throw new NotImplementedException();
        }


        private static void createHashingPassword(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            if (string.IsNullOrEmpty(pin)) throw new ArgumentNullException("Pin is null or Empty");
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }


    }
}

