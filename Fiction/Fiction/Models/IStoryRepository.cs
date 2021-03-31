using System.Collections.Generic;

namespace Fiction.Models
{
    public interface IStoryRepository
    {
        IEnumerable<Story> GetAll();
    }
}