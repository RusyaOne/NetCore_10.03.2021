using Microsoft.AspNetCore.Mvc;
using RestApiExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IEnumerable<News> Get()
        {
            return _newsRepository.GetNews();
        }

        [HttpPost]
        public void Add([FromBody]News news)
        {
            _newsRepository.AddNews(news);
        }

        [HttpDelete]
        public void Delete([FromHeader] int newsId)
        {
            _newsRepository.DeleteNews(newsId);
        }
    }
}