using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.Logic
{
    public class PhoneTypeService : IService<PhoneType>
    {
        private readonly CTNContext _context;

        public PhoneTypeService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<PhoneType> GetAll()
        {
            return _context.PhoneTypeSet.AsEnumerable();
        }

        public void Create(PhoneType phoneType)
        {
            _context.PhoneTypeSet.Add(phoneType);
            _context.SaveChanges();
        }

        public void Update(PhoneType phoneType)
        {
            _context.Entry(phoneType).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(PhoneType phoneType)
        {
            Delete(phoneType.Id);
        }

        public void Delete(int id)
        {
            var phoneType = _context.PhoneTypeSet.First(element => element.Id == id);
            _context.PhoneTypeSet.Remove(phoneType);
            _context.SaveChanges();
        }
    }
}
