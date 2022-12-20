using Microsoft.AspNetCore.Mvc;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.Models;

namespace ProjectTek.ViewComponents
{
    public class ArticlesListViewComponent:ViewComponent
    {
        private readonly IWiredArticleReadRepository _articleRead;

        public ArticlesListViewComponent(IWiredArticleReadRepository articleRead)
        {
            _articleRead = articleRead;
        }

        public IViewComponentResult Invoke()
        {
            var list = _articleRead.GetAll().ToList();
            
            return View(list);
        }
    }
}
