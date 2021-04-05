using Microsoft.EntityFrameworkCore;
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

        public Character Get(int characterId)
        {
            return _dbContext.Characters.SingleOrDefault(character => character.Id.Equals(characterId));
        }

        public IEnumerable<Character> GetAll()
        {
            return _dbContext.Characters;
        }

        public IEnumerable<Character> GetAllWithDependencies()
        {
            return _dbContext.Characters.Include(character => character.Story);
        }

        public void Add(Character character)
        {
            _dbContext.Add(character);
            _dbContext.SaveChanges();
        }
    }
}