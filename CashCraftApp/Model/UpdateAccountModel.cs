using System;
namespace CashCraftApp.Model
{
	public class UpdateAccountModel
	{
        public required string FirstName { get; set; }
        public required string Lastname { get; set; }
        public required string AccountName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Pin { get; set; }
    }
}

