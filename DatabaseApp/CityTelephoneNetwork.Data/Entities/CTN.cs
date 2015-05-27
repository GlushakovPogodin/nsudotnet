using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.CTN")]
    public class CTN : Entity
    {
        public CTN()
        {
            this.ATS = new HashSet<ATS>();
            this.IntercityConversation = new HashSet<IntercityConversation>();
        }
    
        public string City { get; set; }

        [IncludeProjection]
        public virtual ICollection<ATS> ATS { get; set; }
        [IncludeProjection]
        public virtual ICollection<IntercityConversation> IntercityConversation { get; set; }
    }
}
