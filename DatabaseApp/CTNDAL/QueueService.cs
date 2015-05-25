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
    public class QueueService : IService<Queue>
    {
        private readonly CTNContext _context;

        public QueueService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<Queue> GetAll()
        {
            return _context.QueueSet.AsEnumerable();
        }

        public void Create(Queue queue)
        {
            _context.QueueSet.Add(queue);
            _context.SaveChanges();
        }

        public void Update(Queue queue)
        {
            _context.Entry(queue).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Queue queue)
        {
            Delete(queue.Id);
        }

        public void Delete(int id)
        {
            var queue = _context.QueueSet.First(element => element.Id == id);
            _context.QueueSet.Remove(queue);
            _context.SaveChanges();
        }
    }
}
