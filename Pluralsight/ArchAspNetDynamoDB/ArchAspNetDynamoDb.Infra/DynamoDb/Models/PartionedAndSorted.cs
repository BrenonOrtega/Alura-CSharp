namespace ArchAspNetDynamoDb.Api.Models
{
    public abstract class PartionedAndSorted
    {
        public string PartitionKey { get => GetPartitionKeyFormation(); }
        public string SortKey { get => GetSortKeyFormation(); }

        protected abstract string GetPartitionKeyFormation();
        protected abstract string GetSortKeyFormation();
    }
}