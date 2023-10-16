using PizzaPalace.Models;
namespace PizzaPalace.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Category>> Category();
        Task<IEnumerable<Pizza>> GetPizza(string sTerm = "", int categoryId = 0);

    }
}
