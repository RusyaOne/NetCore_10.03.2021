using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class CharactersController : Controller
    {
        private FictionDbContext _dbContext;

        public CharactersController(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["Character"] = _dbContext.Characters.FirstOrDefault();
            return View();
        }
    }
}