using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Caliburn.Micro;
using CityTelephoneNetwork.Logic;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels.Lists
{
    public class QueueTypeListViewModel : PropertyChangedBase
    {
        private ObservableCollection<QueueTypeViewModel> _queueTypeList;
        private IService<QueueType> _queueTypeService;
        private QueueTypeViewModel _selectedQueueType;

        public QueueTypeListViewModel(IService<QueueType> QueueTypeService)
        {
            _queueTypeService = QueueTypeService;
            ItemInit();
            _queueTypeList = new ObservableCollection<QueueTypeViewModel>();
            foreach (var queueType in new List<QueueType>(_queueTypeService.GetAll()))
            {
                var vm = new QueueTypeViewModel();
                vm.SetQueueType(queueType);
                _queueTypeList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedQueueType = new QueueTypeViewModel();
            _selectedQueueType.SetQueueType(new QueueType());
        }

        public QueueTypeViewModel SelectedQueueType
        {
            get { return _selectedQueueType; }
            set
            {
                if (_selectedQueueType == value)
                    return;

                _selectedQueueType = value;
                NotifyOfPropertyChange(() => SelectedQueueType);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<QueueType, QueueType>();
                _queueTypeService.Create(Mapper.Map<QueueType, QueueType>(_selectedQueueType.QueueTypeEntity));
                RefreshList();

            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedQueueType.QueueTypeEntity.Id == 0)
                return;
            try
            {
                _queueTypeService.Update(_selectedQueueType.QueueTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedQueueType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedQueueType.QueueTypeEntity.Id == 0)
                return;
            try
            {
                _queueTypeService.Delete(_selectedQueueType.QueueTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedQueueType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _queueTypeList.Clear();

            _queueTypeList = new ObservableCollection<QueueTypeViewModel>();
            foreach (var queueType in new List<QueueType>(_queueTypeService.GetAll()))
            {
                var vm = new QueueTypeViewModel();
                vm.SetQueueType(queueType);
                _queueTypeList.Add(vm);
            }
            NotifyOfPropertyChange(() => QueueTypeList);
        }

        public ObservableCollection<QueueTypeViewModel> QueueTypeList
        {
            get { return _queueTypeList; }
        }
    }
}
