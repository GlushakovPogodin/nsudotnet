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
    public class QueueTypeService : IService<QueueType>
    {
        private readonly CTNContext _context;

        public QueueTypeService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<QueueType> GetAll()
        {
            return _context.QueueTypeSet.AsEnumerable();
        }

        public void Create(QueueType queueType)
        {
            _context.QueueTypeSet.Add(queueType);
            _context.SaveChanges();
        }

        public void Update(QueueType queueType)
        {
            _context.Entry(queueType).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(QueueType queueType)
        {
            Delete(queueType.Id);
        }

        public void Delete(int id)
        {
            var queueType = _context.QueueTypeSet.First(element => element.Id == id);
            _context.QueueTypeSet.Remove(queueType);
            _context.SaveChanges();
        }
    }
}
