using BasicInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicInfo.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get(int index)
        {
            var news = NewsBase.GetNews();
            ViewData["News"] = news.SingleOrDefault(x => x.Id == index);

            return View();
        }
    }
}