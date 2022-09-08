﻿using AutoMapper;
using Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.DAL.Entities;
using Transaction.DAL.Interfaces;
using Transaction.DTO;
using Transaction.Services.Interfaces;
using Transaction.Services.Mapping;

namespace Transaction.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        //private readonly IMessageSession _messageSession;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository; 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionMap>();
                cfg.AddProfile<TransactionEntityMap>();
            });
            _mapper = config.CreateMapper();
        }
        public async Task<bool> SendTransaction(TransactionDto transactionDto, IMessageSession messageSession)
        {
            TransactionEntity transactionEntity = _mapper.Map<TransactionEntity>(transactionDto);
            transactionEntity.DateOfTransaction = DateTime.UtcNow;
            transactionEntity.Status = DAL.TransactionStatus.Processing;
            transactionEntity.Id = Guid.NewGuid();
            await _transactionRepository.addTransaction(transactionEntity);
            TransactionPayloaded payload = _mapper.Map<TransactionPayloaded>(transactionEntity);
            await messageSession.Send(payload);
            //if saga event failes return false
            return true;
        }

    }
}
