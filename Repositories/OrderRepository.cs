using GastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GastroBarContext _context;
        public OrderRepository(GastroBarContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(string tablenumber)
        {
            return await _context.Orders.Where(x => x.TableNumber == tablenumber).ToListAsync();
        }
    }
}
