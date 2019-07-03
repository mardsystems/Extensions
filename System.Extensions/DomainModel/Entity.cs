using System.BusinessModel;

namespace System.DomainModel
{
    public class Entity : IEntity
    {
        public byte[] Version { get; set; }
    }
}
