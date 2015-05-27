using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class QueueTypeViewModel : PropertyChangedBase
    {
        public QueueType QueueTypeEntity { get; private set; }

        public string Type
        {
            get { return QueueTypeEntity.Type; }
            set
            {
                if (QueueTypeEntity.Type == value) return;
                QueueTypeEntity.Type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public void SetQueueType(QueueType queueType)
        {
            QueueTypeEntity = queueType;
        }
    }
}
