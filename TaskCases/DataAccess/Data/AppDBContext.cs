using Microsoft.EntityFrameworkCore;
using TaskCases.Models;

namespace TaskCases.DataAccess.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Case> cases { get; set; }

        public DbSet<Account> accounts { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Subject> subjects { get; set; }




    }
}
