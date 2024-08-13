namespace TestRabbitmq.RabbitMQs;

public interface IRabitMQProducer
{
    public void SendProductMessage<T>(T message);
}
