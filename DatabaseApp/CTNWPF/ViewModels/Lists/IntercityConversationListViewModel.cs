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
    public class IntercityConversationListViewModel
    {
        private ObservableCollection<IntercityConversationViewModel> _intercityConversationList;
        private IService<IntercityConversation> _intercityConversationService;

        public IntercityConversationListViewModel(IService<IntercityConversation> intercityConversationService)
        {
            _intercityConversationService = intercityConversationService;

             _intercityConversationList = new ObservableCollection<IntercityConversationViewModel>();
            foreach (var intercityConversation in new List<IntercityConversation>(_intercityConversationService.GetAll()))
            {
                var vm = new IntercityConversationViewModel();
                vm.SetIntercityConversation(intercityConversation);
                _intercityConversationList.Add(vm);
            }
        }

        public ObservableCollection<IntercityConversationViewModel> IntercityConversationList
        {
            get { return _intercityConversationList; }
        }
    }
}
