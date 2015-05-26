using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class QueueListViewModel : PropertyChangedBase
    {
        private ObservableCollection<QueueViewModel> _queueList;
        private ObservableCollection<AddressViewModel> _addressList;
        private ObservableCollection<QueueTypeViewModel> _queueTypeList; 

        private IService<Queue> _queueService;
        private IService<Address> _addressService;
        private IService<QueueType> _queueTypeService;

        private QueueViewModel _selectedQueue;

        public QueueListViewModel(IService<Queue> queueService, IService<Address> addressService, IService<QueueType> queueTypeService)
        {
            _queueService = queueService;
            _queueTypeService = queueTypeService;
            _addressService = addressService;
            ItemInit();
            _queueList = new ObservableCollection<QueueViewModel>();
            _addressList = new ObservableCollection<AddressViewModel>();
            _queueTypeList = new BindableCollection<QueueTypeViewModel>();

            foreach (var queue in _queueService.GetAll().ToList())
            {
                var vm = new QueueViewModel();
                vm.SetQueue(queue);
                _queueList.Add(vm);
            }
            foreach (var address in _addressService.GetAll().ToList())
            {
                var vm = new AddressViewModel();
                vm.SetAddress(address);
                _addressList.Add(vm);
            }
            foreach (var queueType in _queueTypeService.GetAll().ToList())
            {
                var vm = new QueueTypeViewModel();
                vm.SetQueueType(queueType);
                _queueTypeList.Add(vm);
            }
        }
        private void ItemInit()
        {
            _selectedQueue = new QueueViewModel();
            var q = new Queue();
            q.Address = new Address();
            q.QueueType = new QueueType();
            _selectedQueue.SetQueue(q);
        }

        public QueueViewModel SelectedQueue
        {
            get { return _selectedQueue; }
            set
            {
                if (_selectedQueue == value)
                    return;

                _selectedQueue = value;
                NotifyOfPropertyChange(() => SelectedQueue);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<Queue, Queue>();
                _queueService.Create(Mapper.Map<Queue, Queue>(_selectedQueue.QueueEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedQueue.QueueEntity.Id == 0)
                return;
            try
            {
                _queueService.Update(_selectedQueue.QueueEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedQueue);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedQueue.QueueEntity.Id == 0)
                return;
            try
            {
                _queueService.Delete(_selectedQueue.QueueEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedQueue);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _queueList.Clear();
            _queueList = new ObservableCollection<QueueViewModel>();
            foreach (var queue in _queueService.GetAll().ToList())
            {
                var vm = new QueueViewModel();
                vm.SetQueue(queue);
                _queueList.Add(vm);
            }
            NotifyOfPropertyChange(() => AddressList);
            NotifyOfPropertyChange(() => QueueTypeList);
            NotifyOfPropertyChange(() => QueueList);
        }

        public ObservableCollection<QueueViewModel> QueueList
        {
            get { return _queueList; }
        }

        public ObservableCollection<QueueTypeViewModel> QueueTypeList
        {
            get { return _queueTypeList; }
        }

        public ObservableCollection<AddressViewModel> AddressList
        {
            get { return _addressList; }
        }
    }
}
