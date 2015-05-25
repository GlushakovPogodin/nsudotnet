using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class QueueListViewModel
    {
        private ObservableCollection<QueueViewModel> _queueList;
        private IService<Queue> _queueService;

        public QueueListViewModel(IService<Queue> queueService)
        {
            _queueService = queueService;

             _queueList = new ObservableCollection<QueueViewModel>();
            foreach (var queue in new List<Queue>(_queueService.GetAll()))
            {
                var vm = new QueueViewModel();
                vm.SetQueue(queue);
                _queueList.Add(vm);
            }
        }

        public ObservableCollection<QueueViewModel> QueueList
        {
            get { return _queueList; }
        }
    }
}
