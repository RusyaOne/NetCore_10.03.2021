using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fiction.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharactersRepository _charactersRepository;

        public CharactersController(ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        public IActionResult Index()
        {
            var characters = _charactersRepository.GetCharacters().ToList();

            return View(characters);
        }
    }
}