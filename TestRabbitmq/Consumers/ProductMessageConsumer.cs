using MassTransit;
using TestRabbitmq.Models;

namespace TestRabbitmq.Consumers
{
    public class ProductMessageConsumer : IConsumer<Product>
    {
        public Task Consume(ConsumeContext<Product> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received Product ID: {message.ProductId}, Name: {message.ProductName}");
            // Add your processing logic here
            return Task.CompletedTask;
        }
    }
}
