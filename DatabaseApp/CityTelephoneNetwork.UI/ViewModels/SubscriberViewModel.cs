using System;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class SubscriberViewModel : PropertyChangedBase
    {
        private SubscriberTypeViewModel _subscriberType;
        public Subscriber SubscriberEntity { get; private set; }

        public void SetSubscriber(Subscriber subscriber)
        {
            SubscriberEntity = subscriber;
            _subscriberType = new SubscriberTypeViewModel();

            _subscriberType.SetSubscriberType(SubscriberEntity.SubscriberType);
        }

        public string Name
        {
            get { return SubscriberEntity.Name; }
            set
            {
                if (SubscriberEntity.Name == value) return;
                SubscriberEntity.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Surname
        {
            get { return SubscriberEntity.Surname; }
            set
            {
                if (SubscriberEntity.Surname == value) return;
                SubscriberEntity.Surname = value;
                NotifyOfPropertyChange(() => Surname);
            }
        }

        public string Patronymic
        {
            get { return SubscriberEntity.Patronymic; }
            set
            {
                if (SubscriberEntity.Patronymic == value) return;
                SubscriberEntity.Patronymic = value;
                NotifyOfPropertyChange(() => Patronymic);
            }
        }

        public string SexStr
        {
            get { return Sex == true ? "m" : "f"; }
        }
        public bool Sex
        {
            get { return SubscriberEntity.Sex; }
            set
            {
                if (SubscriberEntity.Sex == value) return;
                SubscriberEntity.Sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }

        public DateTime BirthDate
        {
            get { return SubscriberEntity.BirthDate; }
            set
            {
                if (SubscriberEntity.BirthDate == value) return;
                SubscriberEntity.BirthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
            }
        }

        public string Type
        {
            get { return SubscriberEntity.SubscriberType == null ? null : SubscriberEntity.SubscriberType.Type; }
        }
        public SubscriberTypeViewModel SubscriberType
        {
            get { return _subscriberType; }
            set
            {
                if(_subscriberType == value)
                    return;

                _subscriberType = value;
                SubscriberEntity.SubscriberType = _subscriberType.SubscriberTypeEntity;
                SubscriberEntity.SubscriberTypeId = _subscriberType.SubscriberTypeEntity.Id;
                NotifyOfPropertyChange(() => SubscriberType);
                NotifyOfPropertyChange(() => Type);
            }
        }
    }
}
