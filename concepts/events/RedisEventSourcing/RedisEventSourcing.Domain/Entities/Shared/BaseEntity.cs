using System.Text;

namespace RedisEventSourcing.Domain.Entities.Shared
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        public override string ToString()
        {
            var idProps = this.GetType()
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty);

            var stringBuilder = new StringBuilder();

            foreach (var prop in idProps)
                stringBuilder.AppendFormat("{0}: {1} - ", prop.Name, prop.GetValue(this));

            return stringBuilder.ToString();
        }
    }
}