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
    public class BalanceService : IService<Balance>
    {
        private readonly CTNContext _context;

        public BalanceService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<Balance> GetAll()
        {
                return _context.BalanceSet.AsEnumerable();
        }

        public void Create(Balance balance)
        {
                _context.BalanceSet.Add(balance);
                _context.SaveChanges();
        }

        public void Update(Balance balance)
        {
                _context.Entry(balance).State = EntityState.Modified;
                _context.SaveChanges();
        }

        public void Delete(Balance balance)
        {
            Delete(balance.Id);
        }

        public void Delete(int id)
        {
                var balance = _context.BalanceSet.First(element => element.Id == id);
                _context.BalanceSet.Remove(balance);
                _context.SaveChanges();
        }
    }
}
