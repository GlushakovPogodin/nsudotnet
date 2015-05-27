using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.SubscriberType")]
    public class SubscriberType : Entity
    {
        public SubscriberType()
        {
            this.Subscriber = new HashSet<Subscriber>();
        }
    
        public string Type { get; set; }

        [IncludeProjection]
        public virtual ICollection<Subscriber> Subscriber { get; set; }
    }
}
