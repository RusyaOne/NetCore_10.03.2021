using BasicInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicInfo.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get(int index)
        {
            var news = _newsRepository.GetNews();
            ViewData["News"] = news.SingleOrDefault(x => x.Id == index);

            return View();
        }
    }
}