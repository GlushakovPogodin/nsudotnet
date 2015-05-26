using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class IntercityStatusListViewModel : PropertyChangedBase
    {
        private ObservableCollection<IntercityStatusViewModel> _intercityStatusList;
        private IService<IntercityStatus> _intercityStatusService;
        private IntercityStatusViewModel _selectedIntercityStatus;

        public IntercityStatusListViewModel(IService<IntercityStatus> intercityStatusService)
        {
            _intercityStatusService = intercityStatusService;
            ItemInit();
            _intercityStatusList = new ObservableCollection<IntercityStatusViewModel>();
            foreach (var intercityStatus in new List<IntercityStatus>(_intercityStatusService.GetAll()))
            {
                var vm = new IntercityStatusViewModel();
                vm.SetIntercityStatus(intercityStatus);
                _intercityStatusList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedIntercityStatus = new IntercityStatusViewModel();
            _selectedIntercityStatus.SetIntercityStatus(new IntercityStatus());
        }

        public IntercityStatusViewModel SelectedIntercityStatus
        {
            get { return _selectedIntercityStatus; }
            set
            {
                if (_selectedIntercityStatus == value)
                    return;

                _selectedIntercityStatus = value;
                NotifyOfPropertyChange(() => SelectedIntercityStatus);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<IntercityStatus, IntercityStatus>();
                _intercityStatusService.Create(Mapper.Map<IntercityStatus, IntercityStatus>(_selectedIntercityStatus.IntercityStatusEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedIntercityStatus.IntercityStatusEntity.Id == 0)
                return;
            try
            {
                _intercityStatusService.Update(_selectedIntercityStatus.IntercityStatusEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedIntercityStatus);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedIntercityStatus.IntercityStatusEntity.Id == 0)
                return;
            try
            {
                _intercityStatusService.Delete(_selectedIntercityStatus.IntercityStatusEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedIntercityStatus);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _intercityStatusList.Clear();

            _intercityStatusList = new ObservableCollection<IntercityStatusViewModel>();
            foreach (var intercityStatus in new List<IntercityStatus>(_intercityStatusService.GetAll()))
            {
                var vm = new IntercityStatusViewModel();
                vm.SetIntercityStatus(intercityStatus);
                _intercityStatusList.Add(vm);
            }
            NotifyOfPropertyChange(() => IntercityStatusList);
        }
        public ObservableCollection<IntercityStatusViewModel> IntercityStatusList
        {
            get { return _intercityStatusList; }
        }
    }
}
