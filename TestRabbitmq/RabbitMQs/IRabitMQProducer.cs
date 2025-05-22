namespace TestRabbitmq.RabbitMQs;

public interface IRabitMQProducer
{
    Task SendProductMessage<T>(T message) where T : class;
}


