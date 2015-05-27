using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class SubscriberTypeViewModel : PropertyChangedBase
    {
        public SubscriberType SubscriberTypeEntity { get; private set; }

        public string Type
        {
            get { return SubscriberTypeEntity.Type; }
            set
            {
                if (SubscriberTypeEntity.Type == value) return;
                SubscriberTypeEntity.Type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public void SetSubscriberType(SubscriberType subscriberType)
        {
            SubscriberTypeEntity = subscriberType;
        }
    }
}
