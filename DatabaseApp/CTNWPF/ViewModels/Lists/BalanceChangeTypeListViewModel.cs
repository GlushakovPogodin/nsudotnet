using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class BalanceChangeTypeListViewModel : PropertyChangedBase
    {
        private ObservableCollection<BalanceChangeTypeViewModel> _balanceChangeTypeList;
        private IService<BalanceChangeType> _balanceChangeTypeService;
        private BalanceChangeTypeViewModel _selectedBalanceChangeType;

        public BalanceChangeTypeListViewModel(IService<BalanceChangeType> balanceChangeTypeService)
        {
            _balanceChangeTypeService = balanceChangeTypeService;
            ItemInit();
            _balanceChangeTypeList = new ObservableCollection<BalanceChangeTypeViewModel>();
            foreach (var balanceChangeType in new List<BalanceChangeType>(_balanceChangeTypeService.GetAll()))
            {
                var vm = new BalanceChangeTypeViewModel();
                vm.SetBalanceChangeType(balanceChangeType);
                _balanceChangeTypeList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedBalanceChangeType = new BalanceChangeTypeViewModel();
            _selectedBalanceChangeType.SetBalanceChangeType(new BalanceChangeType());
        }

        public BalanceChangeTypeViewModel SelectedBalanceChangeType
        {
            get { return _selectedBalanceChangeType; }
            set
            {
                if (_selectedBalanceChangeType == value)
                    return;

                _selectedBalanceChangeType = value;
                NotifyOfPropertyChange(() => SelectedBalanceChangeType);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<BalanceChangeType, BalanceChangeType>();
                _balanceChangeTypeService.Create(Mapper.Map<BalanceChangeType, BalanceChangeType>(_selectedBalanceChangeType.BalanceChangeTypeEntity));
                RefreshList();

            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedBalanceChangeType.BalanceChangeTypeEntity.Id == 0)
                return;
            try
            {
                _balanceChangeTypeService.Update(_selectedBalanceChangeType.BalanceChangeTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedBalanceChangeType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedBalanceChangeType.BalanceChangeTypeEntity.Id == 0)
                return;
            try
            {
                _balanceChangeTypeService.Delete(_selectedBalanceChangeType.BalanceChangeTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedBalanceChangeType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _balanceChangeTypeList.Clear();

            _balanceChangeTypeList = new ObservableCollection<BalanceChangeTypeViewModel>();
            foreach (var balanceChangeType in new List<BalanceChangeType>(_balanceChangeTypeService.GetAll()))
            {
                var vm = new BalanceChangeTypeViewModel();
                vm.SetBalanceChangeType(balanceChangeType);
                _balanceChangeTypeList.Add(vm);
            }
            NotifyOfPropertyChange(() => BalanceChangeTypeList);
        }

        public ObservableCollection<BalanceChangeTypeViewModel> BalanceChangeTypeList
        {
            get { return _balanceChangeTypeList; }
        }
    }
}
