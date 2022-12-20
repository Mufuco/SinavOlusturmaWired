using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectTek.BusinessLayer.Services;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.EntityLayer.Entities;
using ProjectTek.EntityLayer.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace ProjectTek.Controllers
{
    public class WeridArticleController : Controller
    {
        IWiredArticleWriteRepository _wiredWrite;
        IWiredArticleReadRepository _wiredRead;


        public WeridArticleController(IWiredArticleWriteRepository wiredWrite, IWiredArticleReadRepository wiredRead)
        {
            _wiredWrite = wiredWrite;
            _wiredRead = wiredRead;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<VM_WeridArticle> vmList = new();
            XDocument xDoc = new XDocument();
            xDoc = XDocument.Load(ReadStrings.ConnectionString()); ;

            var items = (from x in xDoc.Descendants("item")
                         select new VM_WeridArticle
                         {

                             Title = x.Element("title").Value,
                             Link = x.Element("link").Value,
                             Description = x.Element("description").Value
                         });


            int i = 0;
            foreach (var item in items)
            {
                if (i != 5)
                {
                    if (_wiredRead.GetAll().Where(x => x.Link == item.Link).Count() == 0)
                    {
                        i++;
                        var articles = new WiredArticle
                        {
                            Description = item.Description,
                            Link = item.Link,
                            Title = item.Title

                        };

                        _wiredWrite.Add(articles);
                        _wiredWrite.SaveChanges();
                        vmList.Add(item);

                    }
                    else { vmList.Add(item); i++; }


                }
            }



            return View(vmList);

        }


        public JsonResult DescList(int id)
        {
            var artic = _wiredRead.GetById(id);
            VM_WeridArticle ann = new();

            string link = artic.Link.ToString();

            Uri url = new Uri(link);
            WebClient client = new();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            StringBuilder metin = new StringBuilder();
            HtmlNodeCollection secilenHtmlList = document.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div/div[1]/div[1]/div[1]");
            if (secilenHtmlList != null)
            {
                ann.Description = secilenHtmlList.ToList().FirstOrDefault().InnerText.Trim().ToString(); ;
                var jsonDesc = JsonConvert.SerializeObject(ann);
                return Json(jsonDesc);
            }
            else
            {
                var jsonDesc = JsonConvert.SerializeObject(artic);
                return Json(jsonDesc);
            }




        }
    }
}
