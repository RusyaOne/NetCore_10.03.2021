using System.Collections.Generic;
using System.Linq;

namespace RestApiExample.Models
{
    public class MockNewsRepository : INewsRepository
    {
        private List<News> _news;

        public MockNewsRepository()
        {
            _news = new List<News>
            {
                new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson", IsFake = true},
                new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorName = "Svetlana Sokolova", IsFake = true},
                new News { Id = 2, Title = "Scientists estimed the time of the vaccine invension: it is a summer of 2021", Text = "", AuthorName = "John Jones", IsFake = false },
                new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers", IsFake = false },
                new News { Id = 4, Title = "A species were discovered in Africa: it is blue legless cat", Text = "", AuthorName = "Jimmy Felon", IsFake = true }
            };
        }

        public IEnumerable<News> GetNews()
        {
            return _news;
        }

        public void AddNews(News news)
        {
            _news.Add(news);
        }

        public void DeleteNews(int newsId)
        {
            var news = _news.Single(x => x.Id == newsId);
            _news.Remove(news);
        }
    }
}