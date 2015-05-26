using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class PhoneListViewModel : PropertyChangedBase
    {
        private ObservableCollection<PhoneViewModel> _phoneList;
        private ObservableCollection<PhoneTypeViewModel> _phoneTypeList;
        private ObservableCollection<ATSViewModel> _atsList;
        private ObservableCollection<AddressViewModel> _addressList;
        private ObservableCollection<SubscriberViewModel> _subscriberList;
        private ObservableCollection<IntercityStatusViewModel> _intercityStatusList;

        private IService<Phone> _phoneService;
        private IService<PhoneType> _phoneTypeService;
        private IService<ATS> _atsService;
        private IService<Address> _addressService;
        private IService<Subscriber> _subscriberService;
        private IService<IntercityStatus> _intercityStatusService;

        private PhoneViewModel _selectedPhone;

        public PhoneListViewModel(IService<Phone> phoneService, IService<PhoneType> phoneTypeService, IService<ATS> atsService,
            IService<Address> addressService, IService<Subscriber> subscriberService, IService<IntercityStatus> intercityStatusService)
        {
            _phoneService = phoneService;
            _phoneTypeService = phoneTypeService;
            _atsService = atsService;
            _addressService = addressService;
            _subscriberService = subscriberService;
            _intercityStatusService = intercityStatusService;
            ItemInit();
            _phoneList = new ObservableCollection<PhoneViewModel>();
            foreach (var phone in _phoneService.GetAll().ToList())
            {
                var vm = new PhoneViewModel();
                vm.SetPhone(phone);
                _phoneList.Add(vm);
            }
            _phoneTypeList = new ObservableCollection<PhoneTypeViewModel>();
            foreach (var phoneType in _phoneTypeService.GetAll().ToList())
            {
                var vm = new PhoneTypeViewModel();
                vm.SetPhoneType(phoneType);
                _phoneTypeList.Add(vm);
            }
            _atsList = new ObservableCollection<ATSViewModel>();
            foreach (var ats in _atsService.GetAll().ToList())
            {
                var vm = new ATSViewModel();
                vm.SetATS(ats);
                _atsList.Add(vm);
            }
            _addressList = new ObservableCollection<AddressViewModel>();
            foreach (var address in _addressService.GetAll().ToList())
            {
                var vm = new AddressViewModel();
                vm.SetAddress(address);
                _addressList.Add(vm);
            }
            _subscriberList = new ObservableCollection<SubscriberViewModel>();
            foreach (var subscriber in _subscriberService.GetAll().ToList())
            {
                var vm = new SubscriberViewModel();
                vm.SetSubscriber(subscriber);
                _subscriberList.Add(vm);
            }
            _intercityStatusList = new ObservableCollection<IntercityStatusViewModel>();
            foreach (var intercityStatus in _intercityStatusService.GetAll().ToList())
            {
                var vm = new IntercityStatusViewModel();
                vm.SetIntercityStatus(intercityStatus);
                _intercityStatusList.Add(vm);
            }

        }

        private void ItemInit()
        {
            _selectedPhone = new PhoneViewModel();
            var p = new Phone();
            p.ATS = new ATS();
            p.Subscriber = new Subscriber();
            _selectedPhone.SetPhone(p);
        }

        public PhoneViewModel SelectedPhone
        {
            get { return _selectedPhone; }
            set
            {
                if (_selectedPhone == value)
                    return;

                _selectedPhone = value;
                NotifyOfPropertyChange(() => SelectedPhone);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<Phone, Phone>();
                _phoneService.Create(Mapper.Map<Phone, Phone>(_selectedPhone.PhoneEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedPhone.PhoneEntity.Id == 0)
                return;
            try
            {
                _phoneService.Update(_selectedPhone.PhoneEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedPhone);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedPhone.PhoneEntity.Id == 0)
                return;
            try
            {
                _phoneService.Delete(_selectedPhone.PhoneEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedPhone);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _phoneList.Clear();

            _phoneList = new ObservableCollection<PhoneViewModel>();
            foreach (var phone in _phoneService.GetAll().ToList())
            {
                var vm = new PhoneViewModel();
                vm.SetPhone(phone);
                _phoneList.Add(vm);
            }
            NotifyOfPropertyChange(() => PhoneList);
            NotifyOfPropertyChange(() => PhoneTypeList);
            NotifyOfPropertyChange(() => ATSList);
            NotifyOfPropertyChange(() => AddressList);
            NotifyOfPropertyChange(() => SubscriberList);
            NotifyOfPropertyChange(() => IntercityStatusList);
        }

        public ObservableCollection<PhoneViewModel> PhoneList
        {
            get { return _phoneList; }
        }
        public ObservableCollection<PhoneTypeViewModel> PhoneTypeList
        {
            get { return _phoneTypeList; }
        }
        public ObservableCollection<ATSViewModel> ATSList
        {
            get { return _atsList; }
        }
        public ObservableCollection<AddressViewModel> AddressList
        {
            get { return _addressList; }
        }
        public ObservableCollection<SubscriberViewModel> SubscriberList
        {
            get { return _subscriberList; }
        }
        public ObservableCollection<IntercityStatusViewModel> IntercityStatusList
        {
            get { return _intercityStatusList; }
        }
    }
}
