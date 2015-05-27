using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.IntercityStatus")]
    public class IntercityStatus : Entity
    {
        public IntercityStatus()
        {
            this.Phone = new HashSet<Phone>();
        }
        public string Status { get; set; }

        [IncludeProjection]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
