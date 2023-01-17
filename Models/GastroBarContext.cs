using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Models
{
        public class GastroBarContext : DbContext
        {
            // gastrocontext = luokka minkä kautta päästään tietokantaan käsiksi
            // saman kontekstin kautta pääsee jokaiseen kokoelmaan käsiksi
            public GastroBarContext(DbContextOptions<GastroBarContext> options)
                : base(options)
            {
            }
            public DbSet<Item> Items { get; set; } = null!;
            public DbSet<Basket> Baskets { get; set; } = null!;
            public DbSet<Order> Orders { get; set; } = null!;
            public DbSet<Products> Products { get; set; } = null!;

            
    }
}
