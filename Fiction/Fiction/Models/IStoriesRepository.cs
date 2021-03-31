using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public interface IStoriesRepository
    {
        IEnumerable<Story> GetStories();
    }
}
