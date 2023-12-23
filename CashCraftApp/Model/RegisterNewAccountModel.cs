using System;
using System.ComponentModel.DataAnnotations;

namespace CashCraftApp.Model
{
	public class RegisterNewAccountModel
	{
		public RegisterNewAccountModel()
		{
		}

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        [RegularExpression(@"^[0-9]{4}$")]
        public required string Pin { get; set; }
        [Compare("Pin", ErrorMessage = "Pins do not match")]
        public required string ConfirmPin { get; set; }
    }
}

