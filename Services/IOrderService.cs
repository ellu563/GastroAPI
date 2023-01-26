using GastroAPI.Models;

namespace GastroAPI.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetOrdersAsync(string tablenumber);

        // GET status open
        public Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber);

        // GET status billing
        public Task<IEnumerable<Order>> GetOrdersBillingByAsync(string tablenumber);

    }
}
