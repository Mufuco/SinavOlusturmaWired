using HtmlAgilityPack;
using System.Net;
using System.Text;

namespace ProjectTek.BusinessLayer.Services
{
    public class WiredFullService
    {

        public string GetArticle(string link)
        {
            Uri url = new(link);
            WebClient client = new();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new();
            document.LoadHtml(html);
            HtmlNodeCollection htmlList = document.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div/div[1]/div[1]/div[1]");

            if (htmlList != null)
            {
                string data = htmlList.ToList().FirstOrDefault().InnerText.Trim().ToString();
                return data;
            }
            else { return null; }
        }


    }
}