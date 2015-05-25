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
    public class CTNListViewModel
    {
        private ObservableCollection<CTNViewModel> _ctnList;
        private IService<CTN> _ctnService;

        public CTNListViewModel(IService<CTN> ctnService)
        {
            _ctnService = ctnService;

             _ctnList = new ObservableCollection<CTNViewModel>();
            foreach (var ctn in new List<CTN>(_ctnService.GetAll()))
            {
                var vm = new CTNViewModel();
                vm.SetCTN(ctn);
                _ctnList.Add(vm);
            }
        }

        public ObservableCollection<CTNViewModel> CTNList
        {
            get { return _ctnList; }
        }
    }
}
