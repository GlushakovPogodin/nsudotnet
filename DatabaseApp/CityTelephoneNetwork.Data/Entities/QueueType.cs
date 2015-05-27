using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.QueueType")]
    public class QueueType : Entity
    {
        public QueueType()
        {
            this.Queue = new HashSet<Queue>();
        }
    
        public string Type { get; set; }

        [IncludeProjection]
        public virtual ICollection<Queue> Queue { get; set; }
    }
}
