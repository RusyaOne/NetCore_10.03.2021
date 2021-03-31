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

        public IActionResult Get([FromQuery] int characterId)
        {
            var character = _charactersRepository.GetCharacters().Single(x => x.Id == characterId);

            return View(character);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Character character)
        {
            //_charactersRepository.Add();
            return RedirectToAction("Index", "Home");
        }
    }
}