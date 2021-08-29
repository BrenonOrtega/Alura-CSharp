namespace FireOnWheels.Shared.Messaging
{
    public static class RabbitMqConstants
    {
        public const string RabbitMqUri = "amqp://admin:admin@localhost:5672/";
        public const string JsonMimeType = "application/json";

        public const string RegisterOderExchange = "FireOnWheels-RegisterOrder-Exchange";
        public const string RegisterOderQueue = "FireOnWheels-RegisterOrder-Queue";

        public const string OrderRegisteredExchange = "FireOnWheels-OrderRegistered-Exchange";
        public const string OrderRegisteredQueue = "FireOnWheels-OrderRegistered-Queue";
    }
}