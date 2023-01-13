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

        // hakee id:n perusteella vain yhden
        public async Task<Item> GetItemAsync(long id) 
        {
            // palauttaa tietokannasta löytyvä itemi
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id); // löytyykö tietokannasta ja palauttaa
        }

        // hakee kaikki
        public async Task<IEnumerable<Item>> GetItemsAsync() 
        {
            return await _context.Items.ToListAsync(); // hakee koko listan sisällön (ja imaget)
        }

        // etsitään kaikki sopivat nimen perusteella
        public async Task<IEnumerable<Item>> QueryItems(string query)
        {
            return await _context.Items.Where(x => x.Name.Contains(query)).ToListAsync();
        }

        // etsitään yhtä nimen perusteella
        public async Task<Item> QueryItem(string query)
        {
            Item item = _context.Items.Where(x => x.Name == query).FirstOrDefault();
            return item;
        }

        // nimea varten
        public async Task<Item> GetItemByNameAsync(string name) // hakee id:n perusteella vain yhden
        {
            Item item = _context.Items.Where(x => x.Name == name).FirstOrDefault();
            return item;
        }
        // hintaa varten
        public async Task<Item> GetItemByPriceAsync(string price) // hakee id:n perusteella vain yhden
        {
            Item item = _context.Items.Where(x => x.Price == price).FirstOrDefault();
            return item;
        }
    }
    }
