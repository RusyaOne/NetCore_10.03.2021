using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fiction.Controllers
{
    [Route("[controller]")]
    public class CharactersController : Controller
    {
        private readonly ICharactersRepository _charactersRepository;

        public CharactersController(ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [Route("c/index")]
        [Route("[action]")]
        public IActionResult Index()
        {
            var characters = _charactersRepository.GetCharacters();

            ViewData["Characters"] = characters.ToList();

            return View();
        }
    }
}