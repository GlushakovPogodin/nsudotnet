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
    public class IntercityStatusListViewModel
    {
        private ObservableCollection<IntercityStatusViewModel> _intercityStatusList;
        private IService<IntercityStatus> _intercityStatusService;

        public IntercityStatusListViewModel(IService<IntercityStatus> intercityStatusService)
        {
            _intercityStatusService = intercityStatusService;

             _intercityStatusList = new ObservableCollection<IntercityStatusViewModel>();
            foreach (var intercityStatus in new List<IntercityStatus>(_intercityStatusService.GetAll()))
            {
                var vm = new IntercityStatusViewModel();
                vm.SetIntercityStatus(intercityStatus);
                _intercityStatusList.Add(vm);
            }
        }

        public ObservableCollection<IntercityStatusViewModel> IntercityStatusList
        {
            get { return _intercityStatusList; }
        }
    }
}
