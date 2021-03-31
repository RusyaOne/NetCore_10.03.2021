using System.Collections.Generic;
using System.Linq;

namespace Fiction.Models
{
    public class SqlCharactersRepository : ICharactersRepository
    {
        private readonly FictionDbContext _dbContext;

        public SqlCharactersRepository(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Character> GetAll()
        {
            return _dbContext.Characters;
        }

        public void Add(Character character)
        {
            _dbContext.Add(character);
            _dbContext.SaveChanges();
        }
    }
}