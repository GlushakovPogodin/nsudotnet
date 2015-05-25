using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class BalanceChangeTypeViewModel : PropertyChangedBase
    {
        public BalanceChangeType BalanceChangeTypeEntity { get; private set; }

        public string Type
        {
            get { return BalanceChangeTypeEntity.Type; }
            set
            {
                if (BalanceChangeTypeEntity.Type == value) return;
                BalanceChangeTypeEntity.Type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public void SetBalanceChangeType(BalanceChangeType balanceChangeType)
        {
            BalanceChangeTypeEntity = balanceChangeType;
        }
    }
}
