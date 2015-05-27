using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.Logic
{
    public class SubscriberService : IService<Subscriber>
    {
        private readonly CTNContext _context;

        public SubscriberService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<Subscriber> GetAll()
        {
            return _context.SubscriberSet.AsEnumerable();
        }

        public void Create(Subscriber subscriber)
        {
            _context.SubscriberSet.Add(subscriber);
            _context.SaveChanges();
        }

        public void Update(Subscriber subscriber)
        {
            _context.Entry(subscriber).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Subscriber subscriber)
        {
            Delete(subscriber.Id);
        }

        public void Delete(int id)
        {
            var subscriber = _context.SubscriberSet.First(element => element.Id == id);
            _context.SubscriberSet.Remove(subscriber);
            _context.SaveChanges();
        }
    }
}
