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
    public class BalanceChangeTypeListViewModel
    {
        private ObservableCollection<BalanceChangeTypeViewModel> _balanceChangeTypeList;
        private IService<BalanceChangeType> _balanceChangeTypeService;

        public BalanceChangeTypeListViewModel(IService<BalanceChangeType> balanceChangeTypeService)
        {
            _balanceChangeTypeService = balanceChangeTypeService;

             _balanceChangeTypeList = new ObservableCollection<BalanceChangeTypeViewModel>();
            foreach (var balanceChangeType in new List<BalanceChangeType>(_balanceChangeTypeService.GetAll()))
            {
                var vm = new BalanceChangeTypeViewModel();
                vm.SetBalanceChangeType(balanceChangeType);
                _balanceChangeTypeList.Add(vm);
            }
        }

        public ObservableCollection<BalanceChangeTypeViewModel> BalanceChangeTypeList
        {
            get { return _balanceChangeTypeList; }
        }
    }
}
