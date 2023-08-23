using System.Linq.Expressions;

namespace TaskCases.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);

        Task<List<T>> GetAll();

        Task<int> Add(T entity);
        Task<int> Update(T entity);
    }
}
