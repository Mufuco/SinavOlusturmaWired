using Microsoft.EntityFrameworkCore;
using ProjectTek.CoreLayer.Repositoires.ExamQuesitonRep;
using ProjectTek.DataAccesLayer.Contexts;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Repositoires.ExamQuesitonRep
{
    public class ExamQuesitonReadRepository : ReadRepository<ExamQuestion>, IExamQuestionReadRepository
    {
        
        public ExamQuesitonReadRepository(ProjectTekDbContext context) : base(context)
        {
        }

        
    }
}
