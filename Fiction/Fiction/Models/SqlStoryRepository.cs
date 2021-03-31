using System.Collections.Generic;

namespace Fiction.Models
{
    public class SqlStoryRepository : IStoryRepository
    {
        private readonly FictionDbContext _dbContext;

        public SqlStoryRepository(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Story> GetAll()
        {
            return _dbContext.Stories;
        }
    }
}