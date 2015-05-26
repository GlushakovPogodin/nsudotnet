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
            ATSList = new ATSListViewModel(atsService, atsTypeService, ctnService);
            ATSTypeList = new ATSTypeListViewModel(atsTypeService);
            BalanceChangeTypeList = new BalanceChangeTypeListViewModel(balanceChangeTypeService);
            BalanceList = new BalanceListViewModel(balanceService, balanceChangeTypeService, phoneService);
            CTNList = new CTNListViewModel(ctnService);
            IntercityConversationList = new IntercityConversationListViewModel(intercityConversationService, ctnService, phoneService);
            IntercityStatusList = new IntercityStatusListViewModel(intercityStatusService);
            PhoneList = new PhoneListViewModel(phoneService, phoneTypeService, atsService, addressService, subscriberService, intercityStatusService);
            PhoneTypeList = new PhoneTypeListViewModel(phoneTypeService);
            QueueList = new QueueListViewModel(queueService, addressService, queueTypeService);
            QueueTypeList = new QueueTypeListViewModel(queueTypeService);
            SubscriberList = new SubscriberListViewModel(subscriberService, subscriberTypeService);
            SubscriberTypeList = new SubscriberTypeListViewModel(subscriberTypeService);
        }
        
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
