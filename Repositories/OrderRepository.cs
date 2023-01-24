using GastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GastroBarContext _context;

        const string stat = "open";
        const string statFalse = "closed";
        public OrderRepository(GastroBarContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(string tablenumber)
        {
            // huom. include lause tuo tilauksen esiin, ja statuksella tuodaan esiin vain avoinna olevat tilaukset
            return await _context.Orders.Include(i => i.Orders).Where(x => x.TableNumber == tablenumber && x.Status == stat).ToListAsync();
        }

        // // GET pelkällä orderilla, ei order dto, sama kun ylempi vain eri nimi
        public async Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber)
        {
            // huom. include lause tuo tilauksen esiin, ja statuksella tuodaan esiin vain avoinna olevat tilaukset
            return await _context.Orders.Include(i => i.Orders).Where(x => x.TableNumber == tablenumber && x.Status == stat).ToListAsync();
        }
    }
}
