using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Windows;
using AutoMapper;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;
using CityTelephoneNetwork.Logic;
using CityTelephoneNetwork.UI.ViewModels.Forms;

namespace CityTelephoneNetwork.UI.ViewModels.Lists
{
    public class AddressListViewModel : PropertyChangedBase
    {
        private ObservableCollection<AddressViewModel> _addressList;
        private IService<Address> _addressService;
        private AddressFormViewModel _addressForm;

        public AddressListViewModel(IService<Address> addressService)
        {
            _addressService = addressService;
            _addressForm = new AddressFormViewModel();
            _addressList = new ObservableCollection<AddressViewModel>();
            foreach (var address in new List<Address>(_addressService.GetAll()))
            {
                var vm = new AddressViewModel();
                vm.SetAddress(address);
                _addressList.Add(vm);
            }
            
        }

        public AddressFormViewModel AddressForm
        {
            get { return _addressForm; }
            set
            {
                if (_addressForm == value)
                    return;

                _addressForm = value;
                NotifyOfPropertyChange(() => AddressForm);
            }
        }

        public void Add()
        {
            try
            {
                if (AddressForm.Address.Error != null)
                {
                    MessageBox.Show(string.Format("There is some errors in fields, one of them: {0}",
                        AddressForm.Address.Error));
                    return;
                }
                Mapper.CreateMap<Address, Address>();
                _addressService.Create(Mapper.Map<Address, Address>(AddressForm.Address.AddressEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {
                
            }
        }

        public void Update()
        {
            if (AddressForm.Address.AddressEntity.Id == 0)
                return;
            try
            {
                if (AddressForm.Address.Error != null)
                {
                    MessageBox.Show(string.Format("There is some errors in fields, one of them: {0}",
                        AddressForm.Address.Error));
                    return;
                }
                _addressService.Update(AddressForm.Address.AddressEntity);
                RefreshList();
                AddressForm.ItemInit();
                NotifyOfPropertyChange(() => AddressForm.Address);
            }
            catch (DbUpdateException e)
            {
                
            }
        }

        public void Delete()
        {
            if (AddressForm.Address.AddressEntity.Id == 0)
                return;
            try
            {
                _addressService.Delete(AddressForm.Address.AddressEntity);               
                RefreshList();
                AddressForm.ItemInit();
                NotifyOfPropertyChange(() => AddressForm.Address);
            }
            catch (DbUpdateException e)
            {
                
            }
        }

        

        public void RefreshList()
        {
            _addressList.Clear();
            _addressList = new ObservableCollection<AddressViewModel>();
            foreach (var address in new List<Address>(_addressService.GetAll()))
            {
                var vm = new AddressViewModel();
                vm.SetAddress(address);
                _addressList.Add(vm);
            }
            NotifyOfPropertyChange(() => AddressList);
        }

        public ObservableCollection<AddressViewModel> AddressList
        {
            get { return _addressList; }
        }
    }
}
