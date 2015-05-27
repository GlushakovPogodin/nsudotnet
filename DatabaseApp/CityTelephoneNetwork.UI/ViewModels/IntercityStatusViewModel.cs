using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class IntercityStatusViewModel : PropertyChangedBase
    {
        public IntercityStatus IntercityStatusEntity { get; private set; }

        public void SetIntercityStatus(IntercityStatus intercityStatus)
        {
            IntercityStatusEntity = intercityStatus;
        }

        public string Status
        {
            get { return IntercityStatusEntity.Status; }
            set
            {
                if (IntercityStatusEntity.Status == value) return;
                IntercityStatusEntity.Status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }
    }
}
