using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using AutoMapper;
using Caliburn.Micro;
using CityTelephoneNetwork.Logic;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels.Lists
{
    public class SubscriberListViewModel : PropertyChangedBase
    {
        private ObservableCollection<SubscriberViewModel> _subscriberList;
        private ObservableCollection<SubscriberTypeViewModel> _subscriberTypeList;

        private IService<Subscriber> _subscriberService;
        private IService<SubscriberType> _subscriberTypeService;

        private SubscriberViewModel _selectedSubscriber;

        public SubscriberListViewModel(IService<Subscriber> subscriberService, IService<SubscriberType> subscriberTypeService)
        {
            _subscriberService = subscriberService;
            _subscriberTypeService = subscriberTypeService;
            ItemInit();
            _subscriberList = new ObservableCollection<SubscriberViewModel>();
            _subscriberTypeList = new ObservableCollection<SubscriberTypeViewModel>();

            foreach (var subscriber in _subscriberService.GetAll().ToList())
            {
                var vm = new SubscriberViewModel();
                vm.SetSubscriber(subscriber);
                _subscriberList.Add(vm);
            }
            foreach (var subscriberType in _subscriberTypeService.GetAll().ToList())
            {
                var vm = new SubscriberTypeViewModel();
                vm.SetSubscriberType(subscriberType);
                _subscriberTypeList.Add(vm);
            }
        }
        private void ItemInit()
        {
            _selectedSubscriber = new SubscriberViewModel();
            var q = new Subscriber();
            q.SubscriberType = new SubscriberType();
            _selectedSubscriber.SetSubscriber(q);
        }

        public SubscriberViewModel SelectedSubscriber
        {
            get { return _selectedSubscriber; }
            set
            {
                if (_selectedSubscriber == value)
                    return;

                _selectedSubscriber = value;
                NotifyOfPropertyChange(() => SelectedSubscriber);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<Subscriber, Subscriber>();
                _subscriberService.Create(Mapper.Map<Subscriber, Subscriber>(_selectedSubscriber.SubscriberEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Update()
        {
            if (_selectedSubscriber.SubscriberEntity.Id == 0)
                return;
            try
            {
                _subscriberService.Update(_selectedSubscriber.SubscriberEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedSubscriber);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedSubscriber.SubscriberEntity.Id == 0)
                return;
            try
            {
                _subscriberService.Delete(_selectedSubscriber.SubscriberEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedSubscriber);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _subscriberList.Clear();
            _subscriberList = new ObservableCollection<SubscriberViewModel>();
            foreach (var subscriber in _subscriberService.GetAll().ToList())
            {
                var vm = new SubscriberViewModel();
                vm.SetSubscriber(subscriber);
                _subscriberList.Add(vm);
            }
            NotifyOfPropertyChange(() => SubscriberTypeList);
            NotifyOfPropertyChange(() => SubscriberList);
        }

        public ObservableCollection<SubscriberViewModel> SubscriberList
        {
            get { return _subscriberList; }
        }

        public ObservableCollection<SubscriberTypeViewModel> SubscriberTypeList
        {
            get { return _subscriberTypeList; }
        }
    }
}
