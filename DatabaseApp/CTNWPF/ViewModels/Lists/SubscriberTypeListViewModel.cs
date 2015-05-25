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
    public class SubscriberTypeListViewModel
    {
        private ObservableCollection<SubscriberTypeViewModel> _subscriberTypeList;
        private IService<SubscriberType> _subscriberTypeService;

        public SubscriberTypeListViewModel(IService<SubscriberType> subscriberTypeService)
        {
            _subscriberTypeService = subscriberTypeService;

             _subscriberTypeList = new ObservableCollection<SubscriberTypeViewModel>();
            foreach (var subscriberType in new List<SubscriberType>(_subscriberTypeService.GetAll()))
            {
                var vm = new SubscriberTypeViewModel();
                vm.SetSubscriberType(subscriberType);
                _subscriberTypeList.Add(vm);
            }
        }

        public ObservableCollection<SubscriberTypeViewModel> SubscriberTypeList
        {
            get { return _subscriberTypeList; }
        }
    }
}
