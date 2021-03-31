using System.Collections.Generic;

namespace Fiction.Models
{
    public interface ICharactersRepository
    {
        IEnumerable<Character> GetAll();
        void Add(Character character);
    }
}