using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class BalanceViewModel : PropertyChangedBase
    {
        private PhoneViewModel _phone;
        private BalanceChangeTypeViewModel _balanceChangeType;
        public Balance BalanceEntity { get; private set; }

        public void SetBalance(Balance balance)
        {
            BalanceEntity = balance;
            _phone = new PhoneViewModel();
            _balanceChangeType = new BalanceChangeTypeViewModel();

            _phone.SetPhone(BalanceEntity.Phone);
            _balanceChangeType.SetBalanceChangeType(BalanceEntity.BalanceChangeType);
        }

        public int BalanceChangeValue
        {
            get { return BalanceEntity.BalanceChangeValue; }
            set
            {
                if (BalanceEntity.BalanceChangeValue == value) return;
                BalanceEntity.BalanceChangeValue = value;
                NotifyOfPropertyChange(() => BalanceChangeValue);
            }
        }

        public DateTime BalanceDate
        {
            get { return BalanceEntity.BalanceDate; }
            set
            {
                if (BalanceEntity.BalanceDate == value) return;
                BalanceEntity.BalanceDate = value;
                NotifyOfPropertyChange(() => BalanceDate);
            }
        }

        public string Type
        {
            get { return BalanceEntity.BalanceChangeType == null ? null : BalanceEntity.BalanceChangeType.Type; }
        }
        public BalanceChangeTypeViewModel BalanceChangeType
        {
            get { return _balanceChangeType; }
            set
            {
                if (_balanceChangeType == value)
                    return;

                _balanceChangeType = value;
                BalanceEntity.BalanceChangeType = _balanceChangeType.BalanceChangeTypeEntity;
                BalanceEntity.BalanceChangeTypeId = _balanceChangeType.BalanceChangeTypeEntity.Id;
                NotifyOfPropertyChange(() => BalanceChangeType);
                NotifyOfPropertyChange(() => Type);
            }
        }

        public string PhoneNumber
        {
            get { return BalanceEntity.Phone == null ? null : BalanceEntity.Phone.PhoneNumber; }
        }
        public PhoneViewModel Phone
        {
            get { return _phone; }
            set
            {
                if (_phone == value)
                    return;

                _phone = value;
                BalanceEntity.Phone = _phone.PhoneEntity;
                BalanceEntity.PhoneId = _phone.PhoneEntity.Id;
                NotifyOfPropertyChange(() => Phone);
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }
    }
}
