using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskCases.DataAccess.Data;
using TaskCases.DataAccess.Repository.IRepository;
using TaskCases.Models;

namespace TaskCases.DataAccess.Repository
{
    public class CaseRepository : ICase
    {
        private readonly AppDBContext _db;
        public CaseRepository(AppDBContext db)
        { 
            _db = db;
        }

        public async Task<int> Add(Case entity)
        {
            int result = 0;
            _db.cases.Add(entity);
            result= _db.SaveChanges();
            return result;

        }

        public async Task<List<Case>> GetAll()
        {
            return _db.cases.ToList<Case>();
        }

        public async Task<Case> GetById(Guid id)
        {
            return  _db.cases.FirstOrDefault(x => x.ID == id);
        }

        public async Task<int> Update(Case entity)
        {
            int result = 0;
            _db.cases.Update(entity);
            result = _db.SaveChanges();
            return result;
        }


       


    }

}
