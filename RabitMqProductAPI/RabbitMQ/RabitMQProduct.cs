using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabitMqProductAPI.RabbitMQ
{
    public class RabitMQProduct : IRabitMQProduct
    {
        public void SendProductMess<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5673,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using
                var channel = connection.CreateModel();

            channel.QueueDeclare("demoExchange", exclusive: false);

            var bodyMess = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish(exchange: "demoExchange", routingKey: "directexchange_key", body: bodyMess);
            //Console.ReadKey();
        }

    }
}
