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
    public class PhoneService : IService<Phone>
    {
        private readonly CTNContext _context;

        public PhoneService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<Phone> GetAll()
        {
            return _context.PhoneSet.AsEnumerable();
        }

        public void Create(Phone phone)
        {
            _context.PhoneSet.Add(phone);
            _context.SaveChanges();
        }

        public void Update(Phone phone)
        {
            _context.Entry(phone).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Phone phone)
        {
            Delete(phone.Id);
        }

        public void Delete(int id)
        {
            var phone = _context.PhoneSet.First(element => element.Id == id);
            _context.PhoneSet.Remove(phone);
            _context.SaveChanges();

        }
    }
}
