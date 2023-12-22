using System;
using CashCraftApp.Model;

namespace CashCraftApp.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
		public AutoMapperProfile()
		{
            CreateMap<RegisterNewAccountModel, Account>();
            CreateMap<UpdateAccountModel, Account>();
            CreateMap<Account, GetAccountModel>();
            CreateMap<TransactionRequestDto, Transaction>();

        }
	}
}

