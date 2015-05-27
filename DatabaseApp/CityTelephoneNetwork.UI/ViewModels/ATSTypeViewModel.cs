using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class ATSTypeViewModel : PropertyChangedBase
    {
        public ATSType ATSTypeEntity { get; private set; }

        public string Type
        {
            get { return ATSTypeEntity.Type; }
            set
            {   if (ATSTypeEntity.Type == value) return;
                ATSTypeEntity.Type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public void SetATSType (ATSType atsType)
        {
            ATSTypeEntity = atsType;
        }
    }
}
