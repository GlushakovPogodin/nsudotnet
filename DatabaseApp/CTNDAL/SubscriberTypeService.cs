using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTNDAL.Properties;
using CTNDb;

namespace CTNDAL
{
    public class SubscriberTypeService : IService<SubscriberType>
    {
        private readonly CTNContext _context;

        public SubscriberTypeService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<SubscriberType> GetAll()
        {
            return _context.SubscriberTypeSet.AsEnumerable();
        }

        public void Create(SubscriberType subscriberType)
        {
            _context.SubscriberTypeSet.Add(subscriberType);
            _context.SaveChanges();
        }

        public void Update(SubscriberType subscriberType)
        {
            _context.Entry(subscriberType).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(SubscriberType subscriberType)
        {
            Delete(subscriberType.Id);
        }

        public void Delete(int id)
        {
            var subscriberType = _context.SubscriberTypeSet.First(element => element.Id == id);
            _context.SubscriberTypeSet.Remove(subscriberType);
            _context.SaveChanges();
        }
    }
}
