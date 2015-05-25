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
    public class SubscriberListViewModel
    {
        private ObservableCollection<SubscriberViewModel> _subscriberList;
        private IService<Subscriber> _subscriberService;

        public SubscriberListViewModel(IService<Subscriber> subscriberService)
        {
            _subscriberService = subscriberService;

             _subscriberList = new ObservableCollection<SubscriberViewModel>();
            foreach (var subscriber in new List<Subscriber>(_subscriberService.GetAll()))
            {
                var vm = new SubscriberViewModel();
                vm.SetSubscriber(subscriber);
                _subscriberList.Add(vm);
            }
        }

        public ObservableCollection<SubscriberViewModel> SubscriberList
        {
            get { return _subscriberList; }
        }
    }
}
