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
    public class PhoneListViewModel
    {
        private ObservableCollection<PhoneViewModel> _phoneList;
        private IService<Phone> _phoneService;

        public PhoneListViewModel(IService<Phone> phoneService)
        {
            _phoneService = phoneService;

             _phoneList = new ObservableCollection<PhoneViewModel>();
            foreach (var phone in new List<Phone>(_phoneService.GetAll()))
            {
                var vm = new PhoneViewModel();
                vm.SetPhone(phone);
                _phoneList.Add(vm);
            }
        }

        public ObservableCollection<PhoneViewModel> PhoneList
        {
            get { return _phoneList; }
        }
    }
}
