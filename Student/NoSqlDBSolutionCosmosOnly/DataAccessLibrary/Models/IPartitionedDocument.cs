namespace DataAccessLibrary.Models
{
    public interface IPartitionedDocument
    {
        string Id { get; }
        string PartitionKey { get; }
    }
}
