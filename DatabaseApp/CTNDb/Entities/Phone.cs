using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTNDb
{
    [IncludeProjection]
    [Table("CTNDb.Phone")]
    public class Phone : Entity
    {
        public Phone()
        {
            this.IntercityConversation = new HashSet<IntercityConversation>();
            this.Balance = new HashSet<Balance>();
        }
    
        public int ATSId { get; set; }
        public int AddressId { get; set; }
        public int PhoneTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public int SubscriberId { get; set; }
        public int IntercityStatusId { get; set; }

        [IncludeProjection]
        public virtual ATS ATS { get; set; }
        [IncludeProjection]
        public virtual Address Address { get; set; }
        [IncludeProjection]
        public virtual PhoneType PhoneType { get; set; }
        [IncludeProjection]
        public virtual ICollection<IntercityConversation> IntercityConversation { get; set; }
        [IncludeProjection]
        public virtual Subscriber Subscriber { get; set; }
        [IncludeProjection]
        public virtual ICollection<Balance> Balance { get; set; }
        [IncludeProjection]
        public virtual IntercityStatus IntercityStatus { get; set; }
    }
}
