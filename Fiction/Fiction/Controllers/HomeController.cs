using Fiction.Models;
using Fiction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IStoriesRepository _storiesRepository;

        public HomeController(ICharactersRepository charactersRepository,
            IStoriesRepository storiesRepository)
        {
            _charactersRepository = charactersRepository;
            _storiesRepository = storiesRepository;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                Characters = _charactersRepository.GetCharacters(),
                Stories = _storiesRepository.GetStories()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
