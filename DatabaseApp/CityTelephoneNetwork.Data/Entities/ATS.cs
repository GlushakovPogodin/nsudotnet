using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.ATS")]
    public class ATS : Entity
    {
        public ATS()
        {
            this.Phone = new HashSet<Phone>();
        }
    
        public string Name { get; set; }
        public int CTNId { get; set; }
        public int ATSTypeId { get; set; }

        [IncludeProjection]
        public virtual CTN CTN { get; set; }
        [IncludeProjection]
        public virtual ATSType ATSType { get; set; }
        [IncludeProjection]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
