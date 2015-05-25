using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class PhoneViewModel : PropertyChangedBase
    {
        private PhoneTypeViewModel _phoneType;
        private ATSViewModel _ATS;
        private AddressViewModel _address;
        private SubscriberViewModel _subscriber;
        private IntercityStatusViewModel _intercityStatus;
        public Phone PhoneEntity { get; private set; }

        public void SetPhone(Phone phone)
        {
            PhoneEntity = phone;
            _phoneType = new PhoneTypeViewModel();
            _ATS = new ATSViewModel();
            _address = new AddressViewModel();
            _subscriber = new SubscriberViewModel();
            _intercityStatus = new IntercityStatusViewModel();

            _phoneType.SetPhoneType(PhoneEntity.PhoneType);
            _ATS.SetATS(PhoneEntity.ATS);
            _address.SetAddress(PhoneEntity.Address);
            _subscriber.SetSubscriber(PhoneEntity.Subscriber);
            _intercityStatus.SetIntercityStatus(PhoneEntity.IntercityStatus);
        }

        public string PhoneNumber
        {
            get { return PhoneEntity.PhoneNumber; }
            set
            {
                if (PhoneEntity.PhoneNumber == value) return;
                PhoneEntity.PhoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        public string Type
        {
            get { return PhoneEntity.PhoneType == null ? null : PhoneEntity.PhoneType.Type; }
        }
        public PhoneTypeViewModel PhoneType
        {
            get { return _phoneType; }
            set
            {
                if (_phoneType == value)
                    return;

                _phoneType = value;
                PhoneEntity.PhoneType = _phoneType.PhoneTypeEntity;
                PhoneEntity.PhoneTypeId = _phoneType.PhoneTypeEntity.Id;
                NotifyOfPropertyChange(() => PhoneType);
                NotifyOfPropertyChange(() => Type);
            }
        }

        public string ATSName
        {
            get { return PhoneEntity.ATS == null ? null : PhoneEntity.ATS.Name; }
        }
        public ATSViewModel ATS
        {
            get { return _ATS; }
            set
            {
                if (_ATS == value)
                    return;

                _ATS = value;
                PhoneEntity.ATS = _ATS.ATSEntity;
                PhoneEntity.ATSId = _ATS.ATSEntity.Id;
                NotifyOfPropertyChange(() => ATS);
                NotifyOfPropertyChange(() => ATSName);
            }
        }

        public string AddressStr
        {
            get
            {
                if (PhoneEntity.Address == null)
                    return null;
                var str = string.Format("{0} {1} {2} {3}", 
                    PhoneEntity.Address.District, 
                    PhoneEntity.Address.Street,
                    PhoneEntity.Address.House,
                    PhoneEntity.Address.Flat
                    );

                return str;
            }
        }
        public AddressViewModel Address
        {
            get { return _address; }
            set
            {
                if(_address == value)
                    return;

                _address = value;
                PhoneEntity.Address = _address.AddressEntity;
                PhoneEntity.AddressId = _address.AddressEntity.Id;
                NotifyOfPropertyChange(() => Address);
                NotifyOfPropertyChange(() => AddressStr);
            }
        }

        public string SubscriberName
        {
            get { return PhoneEntity.Subscriber == null ? null : PhoneEntity.Subscriber.Name; }
        }

        public string SubscriberSurame
        {
            get { return PhoneEntity.Subscriber == null ? null : PhoneEntity.Subscriber.Surname; }
        }
        public string SubscriberPatronymic
        {
            get { return PhoneEntity.Subscriber == null ? null : PhoneEntity.Subscriber.Patronymic; }
        }
        public SubscriberViewModel Subscriber
        {
            get { return _subscriber; }
            set
            {
                if(_subscriber == value)
                    return;

                _subscriber = value;
                PhoneEntity.Subscriber = _subscriber.SubscriberEntity;
                PhoneEntity.SubscriberId = _subscriber.SubscriberEntity.Id;
                NotifyOfPropertyChange(() => Subscriber);
                NotifyOfPropertyChange(() => SubscriberName);
                NotifyOfPropertyChange(() => SubscriberSurame);
                NotifyOfPropertyChange(() => SubscriberPatronymic);
            }
        }

        public string IntercityStatusStr
        {
            get { return PhoneEntity.IntercityStatus == null ? null : PhoneEntity.IntercityStatus.Status; }
        }
        public IntercityStatusViewModel IntercityStatus
        {
            get { return _intercityStatus; }
            set
            {
                if(_intercityStatus == value)
                    return;

                _intercityStatus = value;
                PhoneEntity.IntercityStatus = _intercityStatus.IntercityStatusEntity;
                PhoneEntity.IntercityStatusId = _intercityStatus.IntercityStatusEntity.Id;
                NotifyOfPropertyChange(() => IntercityStatus);
                NotifyOfPropertyChange(() => IntercityStatusStr);
            }
        }
    }
}
