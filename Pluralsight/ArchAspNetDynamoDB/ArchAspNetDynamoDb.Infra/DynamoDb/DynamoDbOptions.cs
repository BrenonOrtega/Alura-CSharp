namespace ArchAspNetDynamoDb.Infra.DynamoDb
{
    public class DynamoDbOptions
    {
        public string AccessKey { get; init; }
        public string SecretKey { get; init; }
        public string SecretToken { get; init; }
        public string Region { get; init; }
        public string Url { get; set; }
    }
}
