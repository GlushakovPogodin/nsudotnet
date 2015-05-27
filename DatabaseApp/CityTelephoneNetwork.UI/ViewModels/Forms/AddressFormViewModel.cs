using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels.Forms
{
    public class AddressFormViewModel : PropertyChangedBase
    {
        private AddressViewModel _address;

        public AddressFormViewModel()
        {
            ItemInit();
        }
        public void ItemInit()
        {
            _address = new AddressViewModel();
            _address.SetAddress(new Address());
            NotifyOfPropertyChange(() => Address);
        }
        public AddressViewModel Address
        {
            get { return _address; }
            set
            {
                if (_address == value)
                    return;

                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

    }
}
