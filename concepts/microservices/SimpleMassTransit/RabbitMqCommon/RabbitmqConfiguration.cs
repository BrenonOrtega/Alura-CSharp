namespace RabbitMqCommon
{
    public class RabbitmqConfiguration
    {
        public const string RabbitMQ = "rabbitmq";
        public string Hostname { get; init; }
        public int Port { get; init; }
        public string QueueName { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public int NetworkRecoveryIntervalInSeconds { get; init; }
        public string Vhost { get; init; }
    }
}
