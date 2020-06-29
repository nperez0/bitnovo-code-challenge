using RabbitMQ.Client;
using System;

namespace Bitnovo.Infrastructure.Messaging
{
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
