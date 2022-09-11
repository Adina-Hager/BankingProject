﻿using Account.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.DAL.Interfaces
{
    public interface IOperationRepository
    {
        Task AddToHistoryTable(OperationEntity opEntityFrom, OperationEntity opEntityTo);
        Task<int> GetAccountBalanceByAccountID(int id);
    }
}