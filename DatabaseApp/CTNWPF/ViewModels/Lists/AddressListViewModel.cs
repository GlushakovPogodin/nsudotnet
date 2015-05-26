using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class AddressListViewModel : PropertyChangedBase
    {
        private ObservableCollection<AddressViewModel> _addressList;
        private IService<Address> _addressService;
        private AddressViewModel _selectedAddress;

        public AddressListViewModel(IService<Address> addressService)
        {
            _addressService = addressService;
            _addressList = new ObservableCollection<AddressViewModel>();
            ItemInit();
            foreach (var address in new List<Address>(_addressService.GetAll()))
            {
                var vm = new AddressViewModel();
                vm.SetAddress(address);
                _addressList.Add(vm);
            }
            
        }


        public AddressViewModel SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                if(_selectedAddress == value)
                    return;

                _selectedAddress = value;
                NotifyOfPropertyChange(() => SelectedAddress);
            }
        }

        public void Add()
        {
            try
            {                
                Mapper.CreateMap<Address, Address>();
                _addressService.Create(Mapper.Map<Address, Address>(_selectedAddress.AddressEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {
                
            }
        }

        public void Update()
        {
            if (_selectedAddress.AddressEntity.Id == 0)
                return;
            try
            {
                _addressService.Update(_selectedAddress.AddressEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedAddress);
            }
            catch (DbUpdateException e)
            {
                
            }
        }

        public void Delete()
        {
            if (_selectedAddress.AddressEntity.Id == 0)
                return;
            try
            {
                _addressService.Delete(_selectedAddress.AddressEntity);               
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedAddress);
            }
            catch (DbUpdateException e)
            {
                
            }
        }

        private void ItemInit()
        {
            _selectedAddress = new AddressViewModel();
            _selectedAddress.SetAddress(new Address());
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
