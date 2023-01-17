using GastroAPI.Models;

namespace GastroAPI.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetOrdersAsync(string tablenumber);
    }
}
