namespace PizzaPalace.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Orders>> GetOrders();
    }
}