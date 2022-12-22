using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using ProjectTek.BusinessLayer.Services;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.EntityLayer.Entities;
using ProjectTek.EntityLayer.ViewModels;
using System.Net;
using System.Text;

namespace ProjectTek.ViewComponents
{
    public class ArticleListQuestionViewComponent : ViewComponent
    {
        private readonly IWiredArticleReadRepository _articleRead;
        private readonly ObjectPool<WiredFullService> _pool;

        public ArticleListQuestionViewComponent(IWiredArticleReadRepository articleRead, ObjectPool<WiredFullService> pool)
        {
            _articleRead = articleRead;
            _pool = pool;
        }

        public IViewComponentResult Invoke(int id)
        {
            WiredArticle art = _articleRead.GetById(id);
            var poolit = _pool.Get();
            string desc = poolit.GetArticle(art.Link.ToString());

            _pool.Return(poolit);

            if (desc != null)
            {
                art.Description = desc;

                return View(art);
            }
            else { return View(art); }

        }
    }
}
