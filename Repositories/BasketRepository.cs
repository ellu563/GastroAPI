using GastroAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        // haetaan kaikki tilaukset
        public async Task<IEnumerable<Basket>> GetBasketsAsync()
        {
            return await _context.Baskets.ToListAsync();
        }

        // haetaan yksi id:n perusteella
        public async Task<Basket> GetBasketAsync(long id)
        {
            // huom. tähän voitaisiin vaihtaa että TableNumber, hakee sillon sen perusteella
            return await _context.Baskets.FirstOrDefaultAsync(i => i.Id == id);
        }

        // haetaan poytanumeron perusteella kaikki sen tilaukset listaan
        public async Task<IEnumerable<Basket>> GetBasketsAsync(string tablenumber)
        {
          return await _context.Baskets.Where(x => x.TableNumber == tablenumber).ToListAsync();
        }

        // lisää uusi
        public async Task<Basket> AddBasketAsync(Basket basket)
        {
            _context.Baskets.Add(basket); // lisätään kokoelmaan (muistissa), ei vielä tallennettu tietokantaan 
            try
            {
                await _context.SaveChangesAsync(); //  tallennetaan/contextin tilan päivitys (kutsutaan asynkronista = await)
            }
            catch (Exception e)
            {
                return null;
            }
            return basket;
        }
    }
}
