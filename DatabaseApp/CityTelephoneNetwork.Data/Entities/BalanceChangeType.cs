using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityTelephoneNetwork.Data
{
    [IncludeProjection]
    [Table("CTNDb.BalanceChangeType")]
    public class BalanceChangeType : Entity
    {
        public BalanceChangeType()
        {
            this.Balance = new HashSet<Balance>();
        }
    
        public string Type { get; set; }

        [IncludeProjection]
        public virtual ICollection<Balance> Balance { get; set; }
    }
}
