﻿using Account.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccount(CustomerDTO customerDTO);
        Task<int> Login(LoginDTO loginDTO);
        Task<AccountInfoDTO> GetAccountInfo(int id);
    }
}
