using Microsoft.EntityFrameworkCore;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.CoreLayer.Repositoires
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        void SaveChanges();
    }
}
