using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.PhoneType")]
    public class PhoneType : Entity
    {
        public PhoneType()
        {
            this.Phone = new HashSet<Phone>();
        }
    
        public string Type { get; set; }

        [IncludeProjection]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
