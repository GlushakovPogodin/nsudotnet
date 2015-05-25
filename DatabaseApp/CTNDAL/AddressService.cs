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
    public class AddressService : IService<Address>
    {
        private readonly CTNContext _context;

        public AddressService(CTNContext context)
        {
            this._context = context;
        }
        public IEnumerable<Address> GetAll()
        {
            return _context.AddressSet.AsEnumerable();
        }

        public void Create(Address address)
        {
            _context.AddressSet.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Address address)
        {
            Delete(address.Id);
        }

        public void Delete(int id)
        {
            var address = _context.AddressSet.First(element => element.Id == id);
            _context.AddressSet.Remove(address);
            _context.SaveChanges();
        }
    }
}
