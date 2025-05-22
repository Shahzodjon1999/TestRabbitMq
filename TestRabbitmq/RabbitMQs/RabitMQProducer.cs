using MassTransit;

namespace TestRabbitmq.RabbitMQs;

public class RabitMQProducer : IRabitMQProducer
{
    private readonly IBus _bus;

    public RabitMQProducer(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendProductMessage<T>(T message) where T : class
    {
        await _bus.Publish(message);
    }
}

