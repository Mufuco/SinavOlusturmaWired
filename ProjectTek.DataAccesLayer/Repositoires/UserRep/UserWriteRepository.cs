using ProjectTek.CoreLayer.Repositoires.ExamRep;
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
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ProjectTekDbContext context) : base(context)
        {
        }
    }
}
