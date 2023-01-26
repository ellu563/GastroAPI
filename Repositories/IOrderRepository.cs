using GastroAPI.Models;

namespace GastroAPI.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrdersAsync(string tablenumber); 

        // GET status open
        public Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber); // get poytanumeron perusteella

        // GET status billing
        public Task<IEnumerable<Order>> GetOrdersBillingByAsync(string tablenumber);
    }
}
