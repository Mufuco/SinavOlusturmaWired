using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.CoreLayer.Repositoires
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        bool Add(T model);
        bool AddList(List<T> model);

        bool Remove(T model);
        bool Remove(int id);
        bool Update(T model);
    }
}
