using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using Caliburn.Micro;
using CityTelephoneNetwork.Logic;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels.Lists
{
    public class IntercityConversationListViewModel : PropertyChangedBase
    {
        private ObservableCollection<IntercityConversationViewModel> _intercityConversationList;
        private ObservableCollection<CTNViewModel> _exteriorCTNList;
        private ObservableCollection<PhoneViewModel> _phoneList; 
        private IService<IntercityConversation> _intercityConversationService;
        private IService<CTN> _ctnService;
        private IService<Phone> _phoneService;
        private IntercityConversationViewModel _selectedIntercityConversation;

        public IntercityConversationListViewModel(IService<IntercityConversation> intercityConversationService, IService<CTN> ctnService, IService<Phone> phoneService)
        {
            _intercityConversationService = intercityConversationService;
            _phoneService = phoneService;
            _ctnService = ctnService;
            ItemInit();
            _intercityConversationList = new ObservableCollection<IntercityConversationViewModel>();
            _exteriorCTNList = new ObservableCollection<CTNViewModel>();
            _phoneList = new BindableCollection<PhoneViewModel>();

            foreach (var intercityConversation in _intercityConversationService.GetAll().ToList())
            {
                var vm = new IntercityConversationViewModel();
                vm.SetIntercityConversation(intercityConversation);
                _intercityConversationList.Add(vm);
            }
            foreach (var ctn in _ctnService.GetAll().ToList())
            {
                var vm = new CTNViewModel();
                vm.SetCTN(ctn);
                _exteriorCTNList.Add(vm);
            }
            foreach (var phone in _phoneService.GetAll().ToList())
            {
                var vm = new PhoneViewModel();
                vm.SetPhone(phone);
                _phoneList.Add(vm);
            }
        }
        private void ItemInit()
        {
            _selectedIntercityConversation = new IntercityConversationViewModel();
            var ic = new IntercityConversation(); 
            ic.Phone = new Phone();
            ic.Phone.ATS = new ATS();
            ic.Phone.Subscriber = new Subscriber();
            _selectedIntercityConversation.SetIntercityConversation(ic);
        }

        public IntercityConversationViewModel SelectedIntercityConversation
        {
            get { return _selectedIntercityConversation; }
            set
            {
                if (_selectedIntercityConversation == value)
                    return;

                _selectedIntercityConversation = value;
                NotifyOfPropertyChange(() => SelectedIntercityConversation);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<IntercityConversation, IntercityConversation>();
                _intercityConversationService.Create(Mapper.Map<IntercityConversation, IntercityConversation>(_selectedIntercityConversation.IntercityConversationEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedIntercityConversation.IntercityConversationEntity.Id == 0)
                return;
            try
            {
                _intercityConversationService.Update(_selectedIntercityConversation.IntercityConversationEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedIntercityConversation);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedIntercityConversation.IntercityConversationEntity.Id == 0)
                return;
            try
            {
                _intercityConversationService.Delete(_selectedIntercityConversation.IntercityConversationEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedIntercityConversation);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _intercityConversationList.Clear();
            _intercityConversationList = new ObservableCollection<IntercityConversationViewModel>();
            foreach (var intercityConversation in _intercityConversationService.GetAll().ToList())
            {
                var vm = new IntercityConversationViewModel();
                vm.SetIntercityConversation(intercityConversation);
                _intercityConversationList.Add(vm);
            }
            NotifyOfPropertyChange(() => ExteriorCTNList);
            NotifyOfPropertyChange(() => PhoneList);
            NotifyOfPropertyChange(() => IntercityConversationList);
        }

        public ObservableCollection<IntercityConversationViewModel> IntercityConversationList
        {
            get { return _intercityConversationList; }
        }

        public ObservableCollection<PhoneViewModel> PhoneList
        {
            get { return _phoneList; }
        }

        public ObservableCollection<CTNViewModel> ExteriorCTNList
        {
            get { return _exteriorCTNList; }
        }
    }
}
