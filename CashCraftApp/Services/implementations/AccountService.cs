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
            if (string.IsNullOrEmpty(AccountNumber) || string.IsNullOrEmpty(Pin))
                throw new ArgumentNullException("Pin or AccountNumber cannot be empty");
            var account = _db.Accounts.SingleOrDefault(x => x.AccountNumber == AccountNumber);
            //is account null
            if (account == null)
                throw new ArgumentNullException("Account not available");

            //so user exists,

            if (!VerifyPinHash(Pin, account.PinHash!, account.PinSalt!))
                throw new ArgumentNullException("Wrong Pin inputed");

            //auth successful
            return account;
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
            var account = _db.Accounts.Find(Id);

            if (account != null)
            {
                _db.Accounts.Remove(account);
                _db.SaveChanges();
            }

        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _db.Accounts.ToList();
           
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
           if (!string.IsNullOrWhiteSpace(AccountNumber))
            {
                var account = _db.Accounts.Where(x => x.AccountNumber == AccountNumber).SingleOrDefault();
                if (account != null)
                {
                    return account;
                }
                else
                {
                    throw new ApplicationException("Account not available base on Account Number");
                }
            }
            else
            {
                throw new ApplicationException("Please enter your Account Number");
            }
        }

        public Account GetById(int Id)
        {
            var account = _db.Accounts.Where(x => x.Id == Id).FirstOrDefault();
            if (account !=null)
            return account;

            throw new ArgumentNullException("there is account with this Id");
        }

        public void Update(Account account, string? Pin)
        {
            //TODO: i will do this later
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

        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Pin));
                return computedPinHash.SequenceEqual(pinHash);
            }
        }

    }
}

