using GastroAPI.Models;

namespace GastroAPI.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrdersAsync(string tablenumber); // get poytanumeron perusteella

        // // GET pelkällä orderilla, ei order dto
        public Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber); // get poytanumeron perusteella
    }
}
