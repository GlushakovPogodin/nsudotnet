using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class SubscriberTypeListViewModel : PropertyChangedBase
    {
        private ObservableCollection<SubscriberTypeViewModel> _subscriberTypeList;
        private IService<SubscriberType> _subscriberTypeService;
        private SubscriberTypeViewModel _selectedSubscriberType;

        public SubscriberTypeListViewModel(IService<SubscriberType> subscriberTypeService)
        {
            _subscriberTypeService = subscriberTypeService;
            ItemInit();
            _subscriberTypeList = new ObservableCollection<SubscriberTypeViewModel>();
            foreach (var subscriberType in new List<SubscriberType>(_subscriberTypeService.GetAll()))
            {
                var vm = new SubscriberTypeViewModel();
                vm.SetSubscriberType(subscriberType);
                _subscriberTypeList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedSubscriberType = new SubscriberTypeViewModel();
            _selectedSubscriberType.SetSubscriberType(new SubscriberType());
        }

        public SubscriberTypeViewModel SelectedSubscriberType
        {
            get { return _selectedSubscriberType; }
            set
            {
                if (_selectedSubscriberType == value)
                    return;

                _selectedSubscriberType = value;
                NotifyOfPropertyChange(() => SelectedSubscriberType);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<SubscriberType, SubscriberType>();
                _subscriberTypeService.Create(Mapper.Map<SubscriberType, SubscriberType>(_selectedSubscriberType.SubscriberTypeEntity));
                RefreshList();

            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedSubscriberType.SubscriberTypeEntity.Id == 0)
                return;
            try
            {
                _subscriberTypeService.Update(_selectedSubscriberType.SubscriberTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedSubscriberType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedSubscriberType.SubscriberTypeEntity.Id == 0)
                return;
            try
            {
                _subscriberTypeService.Delete(_selectedSubscriberType.SubscriberTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedSubscriberType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _subscriberTypeList.Clear();

            _subscriberTypeList = new ObservableCollection<SubscriberTypeViewModel>();
            foreach (var subscriberType in new List<SubscriberType>(_subscriberTypeService.GetAll()))
            {
                var vm = new SubscriberTypeViewModel();
                vm.SetSubscriberType(subscriberType);
                _subscriberTypeList.Add(vm);
            }
            NotifyOfPropertyChange(() => SubscriberTypeList);
        }

        public ObservableCollection<SubscriberTypeViewModel> SubscriberTypeList
        {
            get { return _subscriberTypeList; }
        }
    }
}
