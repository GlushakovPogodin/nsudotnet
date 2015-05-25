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
    public class QueueTypeListViewModel
    {
        private ObservableCollection<QueueTypeViewModel> _queueTypeList;
        private IService<QueueType> _queueTypeService;

        public QueueTypeListViewModel(IService<QueueType> queueTypeService)
        {
            _queueTypeService = queueTypeService;

             _queueTypeList = new ObservableCollection<QueueTypeViewModel>();
            foreach (var queueType in new List<QueueType>(_queueTypeService.GetAll()))
            {
                var vm = new QueueTypeViewModel();
                vm.SetQueueType(queueType);
                _queueTypeList.Add(vm);
            }
        }

        public ObservableCollection<QueueTypeViewModel> QueueTypeList
        {
            get { return _queueTypeList; }
        }
    }
}
