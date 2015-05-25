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
    public class ATSService : IService<ATS>
    {
        private readonly CTNContext _context;

        public ATSService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<ATS> GetAll()
        {
             return _context.ATSSet.AsEnumerable();
        }

        public void Create(ATS ats)
        {
            _context.ATSSet.Add(ats);
            _context.SaveChanges();
        }

        public void Delete(ATS ats)
        {
            Delete(ats.Id);
        }

        public void Update(ATS ats)
        {
            _context.Entry(ats).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ats = _context.ATSSet.First(element => element.Id == id);
            _context.ATSSet.Remove(ats);
            _context.SaveChanges();
        }
    }
}
