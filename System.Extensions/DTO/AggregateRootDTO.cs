using System.BusinessModel;

namespace System.DTO
{
    public class AggregateRootDTO : EntityDTO, IAggregateRoot
    {
        public DateTime CreateOn { get; set; }

        public string CreateBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
