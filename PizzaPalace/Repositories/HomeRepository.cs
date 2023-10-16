using Microsoft.EntityFrameworkCore;
using PizzaPalace.Data;
using PizzaPalace.Models;

namespace PizzaPalace.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> Category()
        {
            return await _db.Category.ToListAsync();
        }
        public async Task<IEnumerable<Pizza>> GetPizza(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Pizza> pizzas = await (from pizza in _db.Pizza
                                                      join category in _db.Category
                                                      on pizza.CategoryId equals category.Id
                                                      where string.IsNullOrWhiteSpace(sTerm) || (pizza != null && pizza.Name.ToLower().StartsWith(sTerm))
                                                      select new Pizza
                                                      {
                                                          Id = pizza.Id,
                                                          Name = pizza.Name,
                                                          Price = pizza.Price,
                                                          Size = pizza.Size,
                                                          Description = pizza.Description,
                                                          Image = pizza.Image,
                                                          CategoryId = category.Id
                                                      }
                         ).ToListAsync();
            if (categoryId > 0)
            {
                
                var filteredLaptops = pizzas.Where(a => a.CategoryId == categoryId).ToList();

                pizzas = filteredLaptops;
            }
            return pizzas;
        }
    }
}
