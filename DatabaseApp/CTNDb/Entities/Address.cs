using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTNDb
{
    [IncludeProjection]
    [Table("CTNDb.Address")]
    public class Address : Entity 
    {
        public Address()
        {
            this.Phone = new HashSet<Phone>();
            this.Queue = new HashSet<Queue>();
        }
    
        public string Index { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
       
        [IncludeProjection]
        public virtual ICollection<Phone> Phone { get; set; }
        [IncludeProjection]
        public virtual ICollection<Queue> Queue { get; set; }
    }
}
