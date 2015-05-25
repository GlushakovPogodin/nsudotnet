using System.Collections.Generic;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;
using CTNWPF.ViewModels.Lists;


namespace CTNWPF.ViewModels
{
    public class MainViewModel : Screen
    {
        

        public MainViewModel(
            IService<Address> addressService, IService<ATSType> atsTypeService,
            IService<ATS> atsService, IService<Balance> balanceService,
            IService<BalanceChangeType> balanceChangeTypeService, IService<CTN> ctnService, 
            IService<IntercityConversation> intercityConversationService, 
            IService<IntercityStatus> intercityStatusService, IService<Phone> phoneService, 
            IService<PhoneType> phoneTypeService, IService<Queue> queueService, 
            IService<QueueType> queueTypeService, IService<Subscriber> subscriberService, 
            IService<SubscriberType> subscriberTypeService
            )
        {
            AddressList = new AddressListViewModel(addressService);
            ATSList = new ATSListViewModel(atsService);
            ATSTypeList = new ATSTypeListViewModel(atsTypeService);
            BalanceChangeTypeList = new BalanceChangeTypeListViewModel(balanceChangeTypeService);
            BalanceList = new BalanceListViewModel(balanceService);
            CTNList = new CTNListViewModel(ctnService);
            IntercityConversationList = new IntercityConversationListViewModel(intercityConversationService);
            IntercityStatusList = new IntercityStatusListViewModel(intercityStatusService);
            PhoneList = new PhoneListViewModel(phoneService);
            PhoneTypeList = new PhoneTypeListViewModel(phoneTypeService);
            QueueList = new QueueListViewModel(queueService);
            QueueTypeList = new QueueTypeListViewModel(queueTypeService);
            SubscriberList = new SubscriberListViewModel(subscriberService);
            SubscriberTypeList = new SubscriberTypeListViewModel(subscriberTypeService);

            /*_atsTypeService = atsTypeService;
            _atsTypeList = new ObservableCollection<ATSTypeViewModel>();
            foreach (var atsType in new List<ATSType>(_atsTypeService.GetAll()))
            {
                var vm = new ATSTypeViewModel();
                vm.SetATSType(atsType);
                _atsTypeList.Add(vm);
            }*/
            /*_atsService = atsService;
            _atsList = new ObservableCollection<ATSViewModel>();
            _atsTypeList = new ObservableCollection<ATSTypeViewModel>();
            foreach (var ats in new List<ATS>(_atsService.GetAll()))
            {
                var vm = new ATSViewModel();
                vm.SetATS(ats);
                _atsList.Add(vm);   
 
            }*/
            //Address = new AddressViewModel();
        }

        /*public ObservableCollection<AddressViewModel> AddressList
        {
            get { return _addressList; }
        }*/
        
        public AddressListViewModel AddressList { get; set; }
        public ATSTypeListViewModel ATSTypeList { get; set; }
        public ATSListViewModel ATSList { get; set; }
        public BalanceChangeTypeListViewModel BalanceChangeTypeList { get; set; }
        public BalanceListViewModel BalanceList { get; set; }
        public CTNListViewModel CTNList { get; set; }
        public IntercityConversationListViewModel IntercityConversationList { get; set; }
        public IntercityStatusListViewModel IntercityStatusList { get; set; }
        public PhoneListViewModel PhoneList { get; set; }
        public PhoneTypeListViewModel PhoneTypeList { get; set; }
        public QueueListViewModel QueueList { get; set; }
        public QueueTypeListViewModel QueueTypeList { get; set; }
        public SubscriberListViewModel SubscriberList { get; set; }
        public SubscriberTypeListViewModel SubscriberTypeList { get; set; }

    }
}
