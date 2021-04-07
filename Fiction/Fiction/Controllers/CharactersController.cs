using Fiction.Models;
using Fiction.ViewModels;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index([FromQuery]string name, [FromQuery]int? age)
        {
            var characters = _charactersRepository.GetAll().
                Where(character => character.Name.Equals(name ?? character.Name) && character.Age.Equals(age ?? character.Age)).
                Select(character => 
                    new CharactersIndexViewModel 
                    { 
                        CharacterId = character.Id,
                        CharacterName = character.Name, 
                        StoryName = character.Story.Name
                    }).ToList();

            return View(characters);
        }

        public IActionResult Get(int characterId)
        {
            var character = _charactersRepository.GetAll().Single(x => x.Id == characterId);

            return View(character);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Character character)
        {
            if (ModelState.IsValid)
            {
                _charactersRepository.Add(character);
                return RedirectToAction("Index", "Characters");
            }

            return View();
        }
    }
}