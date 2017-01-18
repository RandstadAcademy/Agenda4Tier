﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.ChainMessage
{
    public interface IChainableMessageService
    {
        void Send(MessagePayload messagePayload);
    }
}
