using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class IntercityConversationViewModel : PropertyChangedBase
    {
        private PhoneViewModel _phone;
        private CTNViewModel _exteriorCTN;
        public IntercityConversation IntercityConversationEntity { get; private set; }

        public void SetIntercityConversation(IntercityConversation intercityConversation)
        {
            IntercityConversationEntity = intercityConversation;
            _phone = new PhoneViewModel();
            _exteriorCTN = new CTNViewModel();

            _phone.SetPhone(IntercityConversationEntity.Phone);
            _exteriorCTN.SetCTN(IntercityConversationEntity.ExteriorCTN);
        }

        public DateTime ConversationDate
        {
            get { return IntercityConversationEntity.ConversationDate; }
            set
            {
                if (IntercityConversationEntity.ConversationDate == value) return;
                IntercityConversationEntity.ConversationDate = value;
                NotifyOfPropertyChange(() => ConversationDate);
            }
        }

        public string ExteriorCity
        {
            get { return IntercityConversationEntity.ExteriorCTN == null ? null : IntercityConversationEntity.ExteriorCTN.City; }
        }
        public CTNViewModel ExteriorCTN
        {
            get { return _exteriorCTN; }
            set
            {
                if (_exteriorCTN == value)
                    return;

                _exteriorCTN = value;
                IntercityConversationEntity.ExteriorCTN = _exteriorCTN.CTNEntity;
                IntercityConversationEntity.ExteriorCTNId = _exteriorCTN.CTNEntity.Id;
                NotifyOfPropertyChange(() => ExteriorCTN);
                NotifyOfPropertyChange(() => ExteriorCity);
            }
        }

        public string PhoneNumber
        {
            get { return IntercityConversationEntity.Phone == null ? null : IntercityConversationEntity.Phone.PhoneNumber; }
        }
        public PhoneViewModel Phone
        {
            get { return _phone; }
            set
            {
                if (_phone == value)
                    return;

                _phone = value;
                IntercityConversationEntity.Phone = _phone.PhoneEntity;
                IntercityConversationEntity.PhoneId = _phone.PhoneEntity.Id;
                NotifyOfPropertyChange(() => Phone);
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }
    }
}
