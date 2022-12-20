using ProjectTek.CoreLayer.Repositoires;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.DataAccesLayer.Contexts;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Repositoires.WiredArticleRep
{
    internal class WiredArticlesWriteRepository : WriteRepository<WiredArticle>, IWiredArticleWriteRepository
    {
        public WiredArticlesWriteRepository(ProjectTekDbContext context) : base(context)
        {
        }
    }
}
