using System.Collections.Generic;

namespace RestApiExample.Models
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews();
        void AddNews(News news);
        void DeleteNews(int newsId);
    }
}