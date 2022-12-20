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
    internal class WiredArticlesReadRepository : ReadRepository<WiredArticle>, IWiredArticleReadRepository
    {
        public WiredArticlesReadRepository(ProjectTekDbContext context) : base(context)
        {
        }
    }
}
