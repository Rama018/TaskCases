using TaskCases.Models;

namespace TaskCases.DataAccess.Repository.IRepository
{
    public interface IContact : IRepository<Contact>
    {
        Task<Contact> GetByName(string name);

    }
}
