using System.BusinessModel;

namespace System.DomainModel
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        public DateTime CreateOn { get; internal set; }

        public string CreateBy { get; internal set; }

        public DateTime ModifiedOn { get; internal set; }

        public string ModifiedBy { get; internal set; }
    }
}
