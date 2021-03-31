using Fiction.Models;
using Fiction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IStoryRepository _storyRepository;

        public HomeController(ICharactersRepository charactersRepository,
            IStoryRepository storyRepository)
        {
            _charactersRepository = charactersRepository;
            _storyRepository = storyRepository;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                Characters = _charactersRepository.GetAll(),
                Stories = _storyRepository.GetAll()
            };

            return View(viewModel);
        }
    }
}