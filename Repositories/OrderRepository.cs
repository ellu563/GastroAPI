using GastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GastroBarContext _context;

        const string stat = "open";
        const string bill = "billing";
        public OrderRepository(GastroBarContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(string tablenumber)
        {
            // huom. include lause tuo tilauksen esiin, ja statuksella tuodaan esiin vain avoinna olevat tilaukset
            return await _context.Orders.Include(i => i.Orders).Where(x => x.TableNumber == tablenumber && x.Status == stat).ToListAsync();
        }

        // GET status "open"
        public async Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber)
        {
            // huom. include lause tuo tilauksen esiin, ja statuksella tuodaan esiin vain avoinna olevat tilaukset
            return await _context.Orders.Include(i => i.Orders).Where(x => x.TableNumber == tablenumber && x.Status == stat).ToListAsync();
        }

        // GET status "billing"
        public async Task<IEnumerable<Order>> GetOrdersBillingByAsync(string tablenumber)
        {
            // huom. include lause tuo tilauksen esiin, ja statuksella tuodaan esiin vain "billing" statuksella olevat tilaukset
            return await _context.Orders.Include(i => i.Orders).Where(x => x.TableNumber == tablenumber && x.Status == bill).ToListAsync();
        }
    }
}
