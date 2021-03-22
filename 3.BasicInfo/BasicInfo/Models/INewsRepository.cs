using System.Collections.Generic;

namespace BasicInfo.Models
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews();
    }
}