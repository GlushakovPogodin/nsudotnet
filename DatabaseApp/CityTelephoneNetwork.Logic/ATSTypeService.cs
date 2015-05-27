using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.Logic
{
    public class ATSTypeService : IService<ATSType>
    {
        private CTNContext _context;

        public ATSTypeService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<ATSType> GetAll()
        {
            return _context.ATSTypeSet.AsEnumerable();           
        }

        public void Create(ATSType atsType)
        {
                _context.ATSTypeSet.Add(atsType);
                _context.SaveChanges();
        }

        public void Update(ATSType atsType)
        {
                _context.Entry(atsType).State = EntityState.Modified;
                _context.SaveChanges();
        }

        public void Delete(ATSType atsType)
        {
            Delete(atsType.Id);
        }

        public void Delete(int id)
        {
                var atsType = _context.ATSTypeSet.First(element => element.Id == id);
                _context.ATSTypeSet.Remove(atsType);
                _context.SaveChanges();
        }

    }
}
