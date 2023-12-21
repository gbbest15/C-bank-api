using System;
namespace CashCraftApp.Model
{
	public class Response
	{
		public required String ResponseCode { get; set; }
		public required String RespomseMessage { get; set; }
		public object? Data { get; set; }

	}
}

	