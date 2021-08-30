namespace FireOnWheels.Shared.Messaging
{
    public static class MassTransitRabbitMqConstants
    {
        //MassTransit uses some different operations from rabbitmq client
        public const string RabbitMqUri = "rabbitmq://localhost/fireonwheels/";
        public const string Username = "admin";
        public const string Password = "admin";
         public const string JsonMimeType = "application/json";

        public const string RegisterOderQueue = "Registerorder.service";
        public const string OrderRegisteredQueue = "orderregistered.service";
        public const string FinanceServiceQueue = "finance.service";
    }
}