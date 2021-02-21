using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQEvent.Events;
using RabbitMQEvent.Events.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMQEvent.Producer
{
    public class ReportRabbitMQProducer
    {
        private readonly IRabbitMQConnection connection;

        public ReportRabbitMQProducer(IRabbitMQConnection _connection)
        {
            connection = _connection;   
        }

        public void PubishReport(string queName,ReportEvent model)
        {
            model.Durum = RaporDurumConvert.RaporDurumEnum(1);
            Thread.Sleep(2000);
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                model.Durum = RaporDurumConvert.RaporDurumEnum(2);
                var message = JsonConvert.SerializeObject(model);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties bprops = channel.CreateBasicProperties();
                bprops.Persistent = true;
                bprops.DeliveryMode = 2;

                channel.ConfirmSelect();
                channel.BasicPublish(exchange: "",routingKey: queName, mandatory: true,basicProperties: bprops, body: body);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("RabbitMQ");
                };
                channel.ConfirmSelect();

            }
        }
    }
}
