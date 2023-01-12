using GastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        // tarvitaan viittaus tietokantaan
        private readonly GastroBarContext _context;

        public BasketRepository(GastroBarContext context)
        {
            _context = context;
        }

        /*
        public async Task<Basket> GetBasketAsync(long id)
        {
            // huom. tähän voidaan vaihtaa että TableNumber, hakee sillon sen perusteella

            return await _context.Baskets.FirstOrDefaultAsync(i => i.Id == id);
        }*/

        public async Task<IEnumerable<Basket>> GetBasketsAsync()
        {
            return await _context.Baskets.ToListAsync();
        }

        // yritetaan nyt hakea kaikki yhden id:n perusteella 563
        public async Task<IEnumerable<Basket>> GetBasketsAsync(long id)
        {
            return await _context.Baskets.Where(i => i.Id == id).ToListAsync();
            // original
            // return await _context.Baskets.ToListAsync();
        }
    }
}
