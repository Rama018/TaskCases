using TaskCases.Models;

namespace TaskCases.DataAccess.Repository.IRepository
{
    public interface IAccount : IRepository<Account>
    {
        Task<Account> GetByName(string name);
    }
}
