using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitsManager.Core.RabbitMQ
{
    public class QueueService : IQueueService
    {
        private Dictionary<string, IModel> channels;

        private readonly IConfiguration _configuration;

        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IModel GetChannel(string queueKey)
        {
            if (channels == null)
                channels = new Dictionary<string, IModel>();

            if (!channels.Keys.Contains(queueKey))
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(_configuration.GetSection("Rabbit").GetSection("Hostname").Value),
                    AutomaticRecoveryEnabled = true
                };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                IDictionary<string, object> args = new Dictionary<string, object>
                {
                    { "x-max-priority", 10 }
                };

                channel.QueueDeclare(queue: queueKey,
                               durable: true,
                               autoDelete: false,
                               exclusive: false,
                               arguments: args);
                channels.Add(queueKey, channel);
            }

            return channels[queueKey];
        }

        public void Send<T>(T message, string queue)
        {
            var properties = GetChannel(queue).CreateBasicProperties();
            properties.Persistent = true;

            GetChannel(queue).BasicPublish(exchange: "",
                routingKey: queue,
                basicProperties: properties,
                body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
        }
    }
}
