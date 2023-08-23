using TaskCases.DataAccess.Data;
using TaskCases.DataAccess.Repository.IRepository;
using TaskCases.Models;

namespace TaskCases.DataAccess.Repository
{
    public class SubjectRepository : ISubject
    {
        private readonly AppDBContext _db;
        public SubjectRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<int> Add(Subject entity)
        {
            int result = 0;
            _db.subjects.Add(entity);
            result = _db.SaveChanges();
            return result;

        }

        public async Task<List<Subject>> GetAll()
        {
            return _db.subjects.ToList<Subject>();
        }

        public async Task<Subject> GetById(Guid id)
        {
            return _db.subjects.Find(id);
        }

        public async Task<int> Update(Subject entity)
        {
            int result = 0;
            _db.subjects.Update(entity);
            result = _db.SaveChanges();
            return result;
        }
    }
}
