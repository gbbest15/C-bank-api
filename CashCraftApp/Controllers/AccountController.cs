using System;
using System.Security.Principal;
using AutoMapper;
using CashCraftApp.Model;
using CashCraftApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashCraftApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private IMapper _mapper;
        public AccountController(IMapper mapper, IAccountService accountService)
		{
            _mapper = mapper;
            _accountService = accountService;

        }


        [HttpPost]
        [Route("register_new_account")]
        public IActionResult RegisterAccount([FromBody] RegisterNewAccountModel reg)
        {
            if (!ModelState.IsValid) return BadRequest(reg);

            //map
            var account = _mapper.Map<Account>(reg);

            return Ok(_accountService.Create(account, reg.Pin, reg.ConfirmPin));
        }
    }
}

