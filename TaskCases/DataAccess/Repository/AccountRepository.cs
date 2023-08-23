using TaskCases.DataAccess.Data;
using TaskCases.DataAccess.Repository.IRepository;
using TaskCases.Models;

namespace TaskCases.DataAccess.Repository
{
    public class AccountRepository : IAccount
    {
        private readonly AppDBContext _db;
        public AccountRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<int> Add(Account entity)
        {
            int result = 0;
            _db.accounts.Add(entity);
            result = _db.SaveChanges();
            return result;

        }

        public async Task<List<Account>> GetAll()
        {
            return _db.accounts.ToList<Account>();
        }

        public async Task<Account> GetById(Guid id)
        {
            return _db.accounts.Find(id);
        }

        public async Task<Account> GetByName(string name)
        {
            return  _db.accounts.FirstOrDefault(acc=>acc.Name== name);
        }

        public async Task<int> Update(Account entity)
        {
            int result = 0;
            _db.accounts.Update(entity);
            result = _db.SaveChanges();
            return result;
        }

    }
}
