using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.Logic
{
    public class IntercityStatusService : IService<IntercityStatus>
    {
        private readonly CTNContext _context;

        public IntercityStatusService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<IntercityStatus> GetAll()
        {
            return _context.IntercityStatusSet.AsEnumerable();
        }

        public void Create(IntercityStatus intercityStatus)
        {
            _context.IntercityStatusSet.Add(intercityStatus);
            _context.SaveChanges();
        }

        public void Update(IntercityStatus intercityStatus)
        {
            _context.Entry(intercityStatus).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(IntercityStatus intercityStatus)
        {
            Delete(intercityStatus.Id);
        }

        public void Delete(int id)
        {
            var intercityStatus = _context.IntercityStatusSet.First(element => element.Id == id);
            _context.IntercityStatusSet.Remove(intercityStatus);
            _context.SaveChanges();
        }
    }
}
