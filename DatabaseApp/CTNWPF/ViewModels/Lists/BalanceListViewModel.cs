using System;
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
    public class BalanceListViewModel : PropertyChangedBase
    {
        private ObservableCollection<BalanceViewModel> _balanceList;
        private ObservableCollection<BalanceChangeTypeViewModel> _balanceChangeTypeList;
        private ObservableCollection<PhoneViewModel> _phoneList; 
        private IService<Balance> _balanceService;
        private IService<BalanceChangeType> _balanceChangeTypeService;
        private IService<Phone> _phoneService;
        private BalanceViewModel _selectedBalance;

        public BalanceListViewModel(IService<Balance> balanceService, IService<BalanceChangeType> balanceChangeTypeService, IService<Phone> phoneService)
        {
            _balanceService = balanceService;
            _phoneService = phoneService;
            _balanceChangeTypeService = balanceChangeTypeService;
            ItemInit();
            _balanceList = new ObservableCollection<BalanceViewModel>();
            _balanceChangeTypeList = new ObservableCollection<BalanceChangeTypeViewModel>();
            _phoneList = new BindableCollection<PhoneViewModel>();

            foreach (var balance in _balanceService.GetAll().ToList())
            {
                var vm = new BalanceViewModel();
                vm.SetBalance(balance);
                _balanceList.Add(vm);
            }
            foreach (var balanceChangeType in _balanceChangeTypeService.GetAll().ToList())
            {
                var vm = new BalanceChangeTypeViewModel();
                vm.SetBalanceChangeType(balanceChangeType);
                _balanceChangeTypeList.Add(vm);
            }
            foreach (var phone in _phoneService.GetAll().ToList())
            {
                var vm = new PhoneViewModel();
                vm.SetPhone(phone);
                _phoneList.Add(vm);
            }
        }
        private void ItemInit()
        {
            _selectedBalance = new BalanceViewModel();
            var b = new Balance();
            b.BalanceChangeType = new BalanceChangeType();
            b.Phone = new Phone();
            b.Phone.ATS = new ATS();
            b.Phone.Subscriber = new Subscriber();
            _selectedBalance.SetBalance(b);
        }

        public BalanceViewModel SelectedBalance
        {
            get { return _selectedBalance; }
            set
            {
                if (_selectedBalance == value)
                    return;

                _selectedBalance = value;
                NotifyOfPropertyChange(() => SelectedBalance);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<Balance, Balance>();
                _balanceService.Create(Mapper.Map<Balance, Balance>(_selectedBalance.BalanceEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedBalance.BalanceEntity.Id == 0)
                return;
            try
            {
                _balanceService.Update(_selectedBalance.BalanceEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedBalance);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedBalance.BalanceEntity.Id == 0)
                return;
            try
            {
                _balanceService.Delete(_selectedBalance.BalanceEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedBalance);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _balanceList.Clear();
            _balanceList = new ObservableCollection<BalanceViewModel>();
            foreach (var ats in _balanceService.GetAll().ToList())
            {
                var vm = new BalanceViewModel();
                vm.SetBalance(ats);
                _balanceList.Add(vm);
            }
            NotifyOfPropertyChange(() => BalanceChangeTypeList);
            NotifyOfPropertyChange(() => PhoneList);
            NotifyOfPropertyChange(() => BalanceList);
        }

        public ObservableCollection<BalanceViewModel> BalanceList
        {
            get { return _balanceList; }
        }

        public ObservableCollection<PhoneViewModel> PhoneList
        {
            get { return _phoneList; }
        }

        public ObservableCollection<BalanceChangeTypeViewModel> BalanceChangeTypeList
        {
            get { return _balanceChangeTypeList; }
        }
    }
}
