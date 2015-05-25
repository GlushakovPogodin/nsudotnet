using System.ComponentModel.DataAnnotations.Schema;

namespace CTNDb
{
    [IncludeProjection]
    [Table("CTNDb.Balance")]
    public class Balance : Entity
    {
        public int BalanceChangeTypeId { get; set; }
        public int BalanceChangeValue { get; set; }
        public System.DateTime BalanceDate { get; set; }
        public int PhoneId { get; set; }

        [IncludeProjection]
        public virtual BalanceChangeType BalanceChangeType { get; set; }
        [IncludeProjection]
        public virtual Phone Phone { get; set; }
    }
}
