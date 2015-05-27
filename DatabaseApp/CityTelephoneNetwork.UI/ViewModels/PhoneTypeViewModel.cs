using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class PhoneTypeViewModel : PropertyChangedBase
    {
        public PhoneType PhoneTypeEntity { get; private set; }

        public string Type
        {
            get { return PhoneTypeEntity.Type; }
            set
            {
                if(PhoneTypeEntity.Type == value)
                    return;
                PhoneTypeEntity.Type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public void SetPhoneType(PhoneType phoneType)
        {
            PhoneTypeEntity = phoneType;
        }
    }
}
