namespace PizzaPalace.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int pizzaId, int qty);
        Task<int> RemoveItem(int pizzaId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();
    }
}