using ProjectTek.CoreLayer.Repositoires.UserRep;
using ProjectTek.DataAccesLayer.Contexts;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Repositoires.UserRep
{
    internal class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ProjectTekDbContext context) : base(context)
        {
        }
    }
}
