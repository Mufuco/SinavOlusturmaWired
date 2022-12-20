using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public ArticleListQuestionViewComponent(IWiredArticleReadRepository articleRead)
        {
            _articleRead = articleRead;
        }

        public IViewComponentResult Invoke(int id)
        {
            WiredArticle art = _articleRead.GetById(id);
            string link = art.Link.ToString();

            Uri url = new Uri(link);
            WebClient client = new();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            StringBuilder metin = new StringBuilder();
            HtmlNodeCollection secilenHtmlList = document.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div/div[1]/div[1]/div[1]");

            if (secilenHtmlList != null) {    
                art.Description = secilenHtmlList.ToList().FirstOrDefault().InnerText.Trim().ToString();

                return View(art);
            }

            return View(art);
        }
    }
}
