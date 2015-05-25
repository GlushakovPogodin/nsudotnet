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
    public class ATSListViewModel
    {
        private ObservableCollection<ATSViewModel> _atsList;
        private IService<ATS> _atsService;

        public ATSListViewModel(IService<ATS> atsService)
        {
            _atsService = atsService;

             _atsList = new ObservableCollection<ATSViewModel>();
            foreach (var ats in new List<ATS>(_atsService.GetAll()))
            {
                var vm = new ATSViewModel();
                vm.SetATS(ats);
                _atsList.Add(vm);
            }
        }

        public ObservableCollection<ATSViewModel> ATSList
        {
            get { return _atsList; }
        }
    }
}
