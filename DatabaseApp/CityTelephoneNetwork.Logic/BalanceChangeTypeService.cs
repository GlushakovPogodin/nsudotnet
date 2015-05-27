using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.Logic
{
    public class BalanceChangeTypeService : IService<BalanceChangeType>
    {

        private readonly CTNContext _context;

        public BalanceChangeTypeService(CTNContext context)
        {
            _context = context;
        }

        public IEnumerable<BalanceChangeType> GetAll()
        {
                return _context.BalanceChangeTypeSet.AsEnumerable();
        }

        public void Create(BalanceChangeType balanceChangeType)
        {
                _context.BalanceChangeTypeSet.Add(balanceChangeType);
                _context.SaveChanges();
        }

        public void Update(BalanceChangeType balanceChangeType)
        {
                _context.Entry(balanceChangeType).State = EntityState.Modified;
                _context.SaveChanges(); 
        }

        public void Delete(BalanceChangeType balanceChangeType)
        {
            Delete(balanceChangeType.Id);
        }

        public void Delete(int id)
        {
                var balanceChangeType = _context.BalanceChangeTypeSet.First(element => element.Id == id);
                _context.BalanceChangeTypeSet.Remove(balanceChangeType);
                _context.SaveChanges();
        }
    }
}
