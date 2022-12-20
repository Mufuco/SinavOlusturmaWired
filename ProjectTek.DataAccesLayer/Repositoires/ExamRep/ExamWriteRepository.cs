using ProjectTek.CoreLayer.Repositoires.ExamRep;
using ProjectTek.DataAccesLayer.Contexts;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Repositoires.ExamRep
{
    internal class ExamWriteRepository : WriteRepository<Exam>, IExamWriteRepository
    {
        public ExamWriteRepository(ProjectTekDbContext context) : base(context)
        {
        }
    }
}
