using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTNDb
{
    [IncludeProjection]
    [Table("CTNDb.ATSType")]
    public class ATSType : Entity
    {
        public ATSType()
        {
            this.ATS = new HashSet<ATS>();
        }
    
        public string Type { get; set; }

        [IncludeProjection]
        public virtual ICollection<ATS> ATS { get; set; }
    }
}
