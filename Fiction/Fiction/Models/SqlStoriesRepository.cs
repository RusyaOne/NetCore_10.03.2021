using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class SqlStoriesRepository : IStoriesRepository
    {
        private readonly FictionDbContext _dbContext;

        public SqlStoriesRepository(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Story> GetStories()
        {
            return _dbContext.Stories;
        }
    }
}