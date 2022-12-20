using Microsoft.EntityFrameworkCore;
using ProjectTek.CoreLayer.Repositoires;
using ProjectTek.DataAccesLayer.Contexts;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Repositoires
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ProjectTekDbContext _context;

        public ReadRepository(ProjectTekDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
       
        public IQueryable<T> GetAll() => Table;

        public T GetById(int id) => Table.FirstOrDefault(p => p.Id == id);

        public T GetSingle(Expression<Func<T, bool>> filter) => Table.FirstOrDefault(filter);


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter) => Table.Where(filter);


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
