using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Core.RabbitMQ
{
    public interface IQueueService
    {
        void Send<T>(T message, string queue);
    }
}
