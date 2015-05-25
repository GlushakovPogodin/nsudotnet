using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTNDb
{
    [IncludeProjection]
    [Table("CTNDb.Subscriber")]
    public class Subscriber : Entity
    {
        public Subscriber()
        {
            this.Phone = new HashSet<Phone>();
        }
    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public bool Sex { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int SubscriberTypeId { get; set; }

        [IncludeProjection]
        public virtual ICollection<Phone> Phone { get; set; }
        [IncludeProjection]
        public virtual SubscriberType SubscriberType { get; set; }
    }
}
