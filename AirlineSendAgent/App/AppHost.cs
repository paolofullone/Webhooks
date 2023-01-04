using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using AirlineSendAgent.Client;
using AirlineSendAgent.Data;
using AirlineSendAgent.Dtos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AirlineSendAgent.App
{
    public class AppHost : IAppHost
    {
        private readonly SendAgentDbContext _context;
        private readonly IWebhookClient _webhookClient;

        public AppHost(SendAgentDbContext context, IWebhookClient webhookClient)
        {
            _context = context;
            _webhookClient = webhookClient;
        }

        public void Run()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                var queueName = channel.QueueDeclare().QueueName;

                channel.QueueBind(queue: queueName,
                    exchange: "trigger",
                    routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                Console.WriteLine ("Listening on the message bus...");

                consumer.Received += async (ModuleHandle, ea) => 
                {
                    Console.WriteLine("Event is triggered!");

                    var body = ea.Body;
                    var notificationMessage = Encoding.UTF8.GetString(body.ToArray());
                    var message = JsonSerializer.Deserialize<NotificationMessageDto>(notificationMessage);

                    var webhookToSend = new FlightDetailChangePayloadDto()
                    {
                        WebhookType = message.WebhookType,
                        WebhookURI = string.Empty,
                        Secret = string.Empty,
                        Publisher = string.Empty,
                        OldPrice = message.OldPrice,
                        NewPrice = message.NewPrice,
                        FlightCode = message.FlightCode
                    };
                    
                    foreach(var whs in _context.WebhookSubscriptions.Where(subs => subs.WebhookType.Equals(message.WebhookType)))
                    {
                        webhookToSend.WebhookURI = whs.WebhookURI;
                        webhookToSend.Secret = whs.Secret;
                        webhookToSend.Publisher = whs.WebhookPublisher;

                        await _webhookClient.SendWebhookNotification(webhookToSend);
                    }

                };

                channel.BasicConsume(queue: queueName,
                        autoAck: true,
                        consumer: consumer);
                
                Console.ReadLine();

            }
        }
    }
}