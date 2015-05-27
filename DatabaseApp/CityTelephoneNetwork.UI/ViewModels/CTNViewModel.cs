using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class CTNViewModel : PropertyChangedBase
    {
        public CTN CTNEntity { get; private set; }

        public void SetCTN(CTN cTN)
        {
            CTNEntity = cTN;
        }

        public string City
        {
            get { return CTNEntity.City; }
            set
            {
                if (CTNEntity.City == value) return;
                CTNEntity.City = value;
                NotifyOfPropertyChange(() => City);
            }
        }
    }
}
