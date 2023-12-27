namespace RabitMqProductAPI.RabbitMQ
{
    public interface IRabitMQProduct
    {
        public void SendProductMess<T>(T mess);
    }
}
