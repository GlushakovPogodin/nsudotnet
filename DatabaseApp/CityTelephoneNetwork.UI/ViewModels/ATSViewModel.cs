using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class ATSViewModel : PropertyChangedBase
    {
        private CTNViewModel _CTN;
        private ATSTypeViewModel _ATSType;
        public ATS ATSEntity { get; private set; }

        public void SetATS(ATS ats)
        {
            ATSEntity = ats;
            _CTN = new CTNViewModel();
            _ATSType = new ATSTypeViewModel();

            _CTN.SetCTN(ATSEntity.CTN);
            _ATSType.SetATSType(ATSEntity.ATSType);
        }

        public string Name
        {
            get { return ATSEntity.Name; }
            set
            {
                if (ATSEntity.Name == value) return;
                ATSEntity.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string City
        {
            get { return ATSEntity.CTN == null ? null : ATSEntity.CTN.City; }
        }

        public CTNViewModel CTN
        {
            get { return _CTN; }
            set
            {
                if (_CTN == value)
                    return;

                _CTN = value;
                ATSEntity.CTN = _CTN.CTNEntity;
                ATSEntity.CTNId = _CTN.CTNEntity.Id;
                NotifyOfPropertyChange(() => CTN);
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Type
        {
            get { return ATSEntity.ATSType == null ? null : ATSEntity.ATSType.Type; }
        }
        public ATSTypeViewModel ATSType
        {
            get { return _ATSType; }
            set
            {
                if(_ATSType == value)
                    return;

                _ATSType = value;
                ATSEntity.ATSType = _ATSType.ATSTypeEntity;
                ATSEntity.ATSTypeId = _ATSType.ATSTypeEntity.Id;
                NotifyOfPropertyChange(() => ATSType);
                NotifyOfPropertyChange(() => Type);
            }
        }
    }
}
