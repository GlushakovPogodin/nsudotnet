using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CTNDb;

namespace CTNWPF.ViewModels
{
    public class QueueViewModel : PropertyChangedBase
    {
        private AddressViewModel _address;
        private QueueTypeViewModel _queueType;
        public Queue QueueEntity { get; private set; }

        public void SetQueue(Queue queue)
        {
            QueueEntity = queue;
            _address = new AddressViewModel();
            _queueType = new QueueTypeViewModel();

            _address.SetAddress(QueueEntity.Address);
            _queueType.SetQueueType(QueueEntity.QueueType);
        }

        public int Priority
        {
            get { return QueueEntity.Priority; }
            set
            {
                if (QueueEntity.Priority == value) return;
                QueueEntity.Priority = value;
                NotifyOfPropertyChange(() => Priority);
            }
        }

        public string AddressStr
        {
            get
            {
                if (QueueEntity.Address == null)
                    return null;
                var str = string.Format("{0} {1} {2} {3}",
                    QueueEntity.Address.District,
                    QueueEntity.Address.Street,
                    QueueEntity.Address.House,
                    QueueEntity.Address.Flat
                    );

                return str;
            }
        }

        public AddressViewModel Address
        {
            get { return _address; }
            set
            {
                if (_address == value)
                    return;

                _address = value;
                QueueEntity.Address = _address.AddressEntity;
                QueueEntity.AddressId = _address.AddressEntity.Id;
                NotifyOfPropertyChange(() => Address);
                NotifyOfPropertyChange(() => AddressStr);
            }
        }

        public string Type
        {
            get { return QueueEntity.QueueType == null ? null : QueueEntity.QueueType.Type; }
        }
        public QueueTypeViewModel QueueType
        {
            get { return _queueType; }
            set
            {
                if (_queueType == value)
                    return;

                _queueType = value;
                QueueEntity.QueueType = _queueType.QueueTypeEntity;
                QueueEntity.QueueTypeId = _queueType.QueueTypeEntity.Id;
                NotifyOfPropertyChange(() => QueueType);
                NotifyOfPropertyChange(() => Type);
            }
        }
    }
}
