using GastroAPI.Models;

namespace GastroAPI.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrdersAsync(string tablenumber); // get poytanumeron perusteella
    }
}
