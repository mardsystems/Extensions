namespace System.BusinessModel
{
    public interface IAggregateRoot : IEntity
    {
        DateTime CreateOn { get; }

        string CreateBy { get; }

        DateTime ModifiedOn { get; }

        string ModifiedBy { get; }
    }
}
