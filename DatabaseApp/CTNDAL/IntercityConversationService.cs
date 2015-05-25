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
    public class IntercityConversationService : IService<IntercityConversation>
    {
        private readonly CTNContext _context;

        public IntercityConversationService(CTNContext context)
        {
            _context = context;
        }
        public IEnumerable<IntercityConversation> GetAll()
        {
             return _context.IntercityConversationSet.AsEnumerable();
        }

        public void Create(IntercityConversation intercityConversation)
        {
            _context.IntercityConversationSet.Add(intercityConversation);
            _context.SaveChanges();
        }

        public void Update(IntercityConversation intercityConversation)
        {
            _context.Entry(intercityConversation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(IntercityConversation intercityConversation)
        {
            Delete(intercityConversation.Id);
        }

        public void Delete(int id)
        {
            var intervityConversation = _context.IntercityConversationSet.First(element => element.Id == id);
            _context.IntercityConversationSet.Remove(intervityConversation);
            _context.SaveChanges();
        }
    }
}
