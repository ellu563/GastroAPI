using GastroAPI.Models;

namespace GastroAPI.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetOrdersAsync(string tablenumber);

        // // GET pelkällä orderilla, ei order dto
        public Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber);
    }
}
