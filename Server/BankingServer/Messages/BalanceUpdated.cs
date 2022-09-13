﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class BalanceUpdated:IEvent
    {
        public bool BalanceUpdatedSucceeded { get; set; }
        public Guid TransactionId { get; set; }
        public string FailureReason { get; set; }

    }
}
