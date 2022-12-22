using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using ProjectTek.BusinessLayer.Services;
using ProjectTek.CoreLayer.Repositoires.WiredArticleRep;
using ProjectTek.EntityLayer.Entities;
using ProjectTek.EntityLayer.ViewModels;
using System.Xml.Linq;

namespace ProjectTek.Controllers
{
    public class WeridArticleController : Controller
    {
      private readonly  IWiredArticleWriteRepository _wiredWrite;
        private readonly IWiredArticleReadRepository _wiredRead;
        private readonly ObjectPool<WiredFullService> _pool;

        public WeridArticleController(IWiredArticleWriteRepository wiredWrite, IWiredArticleReadRepository wiredRead, ObjectPool<WiredFullService> pool)
        {
            _wiredWrite = wiredWrite;
            _wiredRead = wiredRead;
            _pool = pool;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<VM_WeridArticle> vmList = new();
            XDocument xDoc = new ();
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
                    if (_wiredRead.GetAll().Where(x => x.Link == item.Link).Any() == false)
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
            var poolit = _pool.Get();

            string desc = poolit.GetArticle(artic.Link.ToString());

            _pool.Return(poolit);

            if (desc!=null)
            {
                artic.Description = desc;
                var jsonDesc = JsonConvert.SerializeObject(artic);
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
