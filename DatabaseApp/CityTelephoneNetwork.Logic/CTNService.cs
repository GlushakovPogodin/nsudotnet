using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.Logic
{
    public class CTNService : IService<CTN>
    {
        private readonly CTNContext _context;

        public CTNService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<CTN> GetAll()
        {
                return _context.CTNSet.AsEnumerable();
        }

        public void Create(CTN ctn)
        {
                _context.CTNSet.Add(ctn);
                _context.SaveChanges();
        }

        public void Update(CTN ctn)
        {
                _context.Entry(ctn).State = EntityState.Modified;
                _context.SaveChanges();
        }

        public void Delete(CTN ctn)
        {
            Delete(ctn.Id);
        }

        public void Delete(int id)
        {
                var ctn = _context.CTNSet.First(element => element.Id == id);
                _context.CTNSet.Remove(ctn);
                _context.SaveChanges();
        }
    }
}
