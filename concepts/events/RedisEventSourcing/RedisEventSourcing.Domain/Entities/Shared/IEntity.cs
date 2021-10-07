namespace RedisEventSourcing.Domain.Entities.Shared
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}