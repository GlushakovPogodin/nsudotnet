using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.IntercityConversation")]
    public class IntercityConversation : Entity
    {
        public System.DateTime ConversationDate { get; set; }
        public int PhoneId { get; set; }

        public int ExteriorCTNId { get; set; }

        [IncludeProjection]
        public virtual CTN ExteriorCTN { get; set; }
        [IncludeProjection]
        public virtual Phone Phone { get; set; }
    }
}
