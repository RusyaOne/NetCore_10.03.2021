using System.Collections.Generic;

namespace Fiction.Models
{
    public interface ICharactersRepository
    {
        Character Get(int characterId);
        IEnumerable<Character> GetAll();
        IEnumerable<Character> GetAllWithDependencies();
        void Add(Character character);
    }
}