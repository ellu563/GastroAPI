using GastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Repositories
{
    // tietokantaa käsitellään ainoastaan repository tasolla, hakee datan ja tallentaan datan tietokantaan
    public class ItemRepository : IItemRepository // toteuttaa rajapinnan IItemRepository
    {
        // tarvitaan viittaus tietokantaan
        private readonly GastroBarContext _context;

        public ItemRepository(GastroBarContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync() // hakee kaikki
        {
            return await _context.Items.ToListAsync(); // hakee koko listan sisällön (ja imaget)
        }

        public async Task<Item> GetItemAsync(long id) // hakee id:n perusteella vain yhden
        {
            // palauttaa tietokannasta löytyvä itemi
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id); // löytyykö tietokannasta ja palauttaa
        }

        public async Task<IEnumerable<Item>> QueryItems(string query)
        {
            return await _context.Items.Where(x => x.Name.Contains(query)).ToListAsync();
        }
    }
    }
