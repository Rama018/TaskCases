using TaskCases.DataAccess.Data;
using TaskCases.DataAccess.Repository.IRepository;
using TaskCases.Models;

namespace TaskCases.DataAccess.Repository
{
    public class ContactRepository : IContact 
    {
        private readonly AppDBContext _db;
        public ContactRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<int> Add(Contact entity)
        {
            int result = 0;
            _db.contacts.Add(entity);
            result = _db.SaveChanges();
            return result;

        }

        public async Task<List<Contact>> GetAll()
        {
            return _db.contacts.ToList<Contact>();
        }

        public async Task<Contact> GetById(Guid id)
        {
            return _db.contacts.Find(id);
        }

        public async Task<Contact> GetByName(string name)
        {
            return  _db.contacts.FirstOrDefault(x=>x.Name == name);
        }

        public async Task<int> Update(Contact entity)
        {
            int result = 0;
            _db.contacts.Update(entity);
            result = _db.SaveChanges();
            return result;
        }
    }
}
