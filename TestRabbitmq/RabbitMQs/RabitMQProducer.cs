using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;
using TestRabbitmq.Models;

namespace TestRabbitmq.RabbitMQs;

public class RabitMQProducer : IRabitMQProducer
{
    private readonly RabbitMQSettings _rabbitMQSettings;

    public RabitMQProducer(IOptions<RabbitMQSettings> rabbitMQSettings)
    {
        _rabbitMQSettings = rabbitMQSettings.Value;
    }
    public void SendProductMessage<T>(T message)
    {
        // Here we specify the Rabbit MQ Server. We use rabbitmq docker image and use it
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMQSettings.HostName,
            UserName = _rabbitMQSettings.UserName,
            Password = _rabbitMQSettings.Password,
            Port = _rabbitMQSettings.Port
        };

        // Create the RabbitMQ connection using connection factory details as i mentioned above
        //var connection = factory.CreateConnection();
        int retries = 5;
        while (retries > 0)
        {
            try
            {
                using (var connection = factory.CreateConnection())
                {
                        // Here we create channel with session and model
                        using var channel = connection.CreateModel();

                        // Declare the queue after mentioning name and a few property related to that
                        channel.QueueDeclare("Product", exclusive: false);

                        // Serialize the message
                        var json = JsonConvert.SerializeObject(message);
                        var body = Encoding.UTF8.GetBytes(json);

                        // Put the data on to the product queue
                        channel.BasicPublish(exchange: "", routingKey: "product", body: body);
                    break;
                }
            }
            catch (BrokerUnreachableException ex)
            {
                retries--;
                if (retries == 0)
                {
                    throw;
                }
                Thread.Sleep(2000);  // Wait 2 seconds before retrying
            }
        }


        //using (var connection = factory.CreateConnection())
        //{
        //    // Here we create channel with session and model
        //    using var channel = connection.CreateModel();

        //    // Declare the queue after mentioning name and a few property related to that
        //    channel.QueueDeclare("Product", exclusive: false);

        //    // Serialize the message
        //    var json = JsonConvert.SerializeObject(message);
        //    var body = Encoding.UTF8.GetBytes(json);

        //    // Put the data on to the product queue
        //    channel.BasicPublish(exchange: "", routingKey: "product", body: body);
        //}
    }
}
