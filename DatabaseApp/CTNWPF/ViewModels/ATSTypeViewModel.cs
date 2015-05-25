using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class ATSTypeViewModel : PropertyChangedBase
    {
        public ATSType AtsTypeEntity { get; private set; }

        public string Type
        {
            get { return AtsTypeEntity.Type; }
            set
            {   if (AtsTypeEntity.Type == value) return;
                AtsTypeEntity.Type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public void SetATSType (ATSType atsType)
        {
            AtsTypeEntity = atsType;
        }
    }
}
