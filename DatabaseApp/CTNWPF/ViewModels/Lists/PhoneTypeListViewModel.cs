using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class PhoneTypeListViewModel : PropertyChangedBase
    {
        private ObservableCollection<PhoneTypeViewModel> _phoneTypeList;
        private IService<PhoneType> _phoneTypeService;
        private PhoneTypeViewModel _selectedPhoneType;

        public PhoneTypeListViewModel(IService<PhoneType> phoneTypeService)
        {
            _phoneTypeService = phoneTypeService;
            ItemInit();
            _phoneTypeList = new ObservableCollection<PhoneTypeViewModel>();
            foreach (var phoneType in new List<PhoneType>(_phoneTypeService.GetAll()))
            {
                var vm = new PhoneTypeViewModel();
                vm.SetPhoneType(phoneType);
                _phoneTypeList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedPhoneType = new PhoneTypeViewModel();
            _selectedPhoneType.SetPhoneType(new PhoneType());
        }

        public PhoneTypeViewModel SelectedPhoneType
        {
            get { return _selectedPhoneType; }
            set
            {
                if (_selectedPhoneType == value)
                    return;

                _selectedPhoneType = value;
                NotifyOfPropertyChange(() => SelectedPhoneType);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<PhoneType, PhoneType>();
                _phoneTypeService.Create(Mapper.Map<PhoneType, PhoneType>(_selectedPhoneType.PhoneTypeEntity));
                RefreshList();

            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedPhoneType.PhoneTypeEntity.Id == 0)
                return;
            try
            {
                _phoneTypeService.Update(_selectedPhoneType.PhoneTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedPhoneType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedPhoneType.PhoneTypeEntity.Id == 0)
                return;
            try
            {
                _phoneTypeService.Delete(_selectedPhoneType.PhoneTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedPhoneType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _phoneTypeList.Clear();

            _phoneTypeList = new ObservableCollection<PhoneTypeViewModel>();
            foreach (var phoneType in new List<PhoneType>(_phoneTypeService.GetAll()))
            {
                var vm = new PhoneTypeViewModel();
                vm.SetPhoneType(phoneType);
                _phoneTypeList.Add(vm);
            }
            NotifyOfPropertyChange(() => PhoneTypeList);
        }

        public ObservableCollection<PhoneTypeViewModel> PhoneTypeList
        {
            get { return _phoneTypeList; }
        }
    }
}
