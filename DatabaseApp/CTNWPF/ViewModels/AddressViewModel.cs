using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class AddressViewModel : PropertyChangedBase
    {
        public Address AddressEntity { get; private set; }

        public void SetAddress(Address address)
        {
            AddressEntity = address;
        }

        public string Index
        {
            get { return AddressEntity.Index; }
            set
            {
                if(AddressEntity.Index == value)
                    return;

                AddressEntity.Index = value;
                NotifyOfPropertyChange(() => Index);
            }
        }

        public string District
        {
            get { return AddressEntity.District; }
            set
            {
                if (AddressEntity.District == value)
                    return;

                AddressEntity.District = value;
                NotifyOfPropertyChange(() => District);
            }
        }

        public string Street
        {
            get { return AddressEntity.Street; }
            set
            {
                if (AddressEntity.Street == value)
                    return;

                AddressEntity.Street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string House
        {
            get { return AddressEntity.House; }
            set
            {
                if (AddressEntity.House == value)
                    return;

                AddressEntity.House = value;
                NotifyOfPropertyChange(() => House);
            }
        }

        public string Flat
        {
            get { return AddressEntity.Flat; }
            set
            {
                if (AddressEntity.Flat == value)
                    return;

                AddressEntity.Flat = value;
                NotifyOfPropertyChange(() => Flat);
            }
        }
    }
}
