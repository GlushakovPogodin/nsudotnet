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
    public class BalanceListViewModel
    {
        private ObservableCollection<BalanceViewModel> _balanceList;
        private IService<Balance> _balanceService;

        public BalanceListViewModel(IService<Balance> balanceService)
        {
            _balanceService = balanceService;

             _balanceList = new ObservableCollection<BalanceViewModel>();
            foreach (var balance in new List<Balance>(_balanceService.GetAll()))
            {
                var vm = new BalanceViewModel();
                vm.SetBalance(balance);
                _balanceList.Add(vm);
            }
        }

        public ObservableCollection<BalanceViewModel> BalanceList
        {
            get { return _balanceList; }
        }
    }
}
