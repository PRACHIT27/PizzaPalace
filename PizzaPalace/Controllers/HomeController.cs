using Microsoft.AspNetCore.Mvc;
using PizzaPalace.Models;
using System.Diagnostics;
using PizzaPalace.Repositories;
using System.ComponentModel.Design;
using System.IO;
using PizzaPalace.Models.DTO;

namespace PizzaPalace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }
        public async Task<IActionResult> Index(string sterm = "", int categoryId = 0)
        {
            IEnumerable<Pizza> pizzas = await _homeRepository.GetPizza(sterm, categoryId);
            IEnumerable<Category> categories = await _homeRepository.Category();
            PizzaDisplay pizzaDisplay = new PizzaDisplay
            {
                Pizza = pizzas,
                Category = categories,
                STerm = sterm,
                CategoryId = categoryId
            };

            return View(pizzaDisplay);
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