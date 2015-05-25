using System.ComponentModel.DataAnnotations.Schema;

namespace CTNDb
{
    [IncludeProjection]
    [Table("CTNDb.Queue")]
    public class Queue : Entity
    {
        public int Priority { get; set; }
        public int QueueTypeId { get; set; }
        public int AddressId { get; set; }

        [IncludeProjection]
        public virtual QueueType QueueType { get; set; }
        [IncludeProjection]
        public virtual Address Address { get; set; }
    }
}
