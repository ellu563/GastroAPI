using GastroAPI.Models;

namespace GastroAPI.Repositories
{
    public interface IBasketRepository
    {
        
        public Task<Basket> GetBasketAsync(long id); // get yhdelle id:n perusteella
        
        public Task<IEnumerable<Basket>> GetBasketsAsync(); // get koko listalle
        
        public Task<IEnumerable<Basket>> GetBasketsAsync(string tablenumber); // get poytanumeron perusteella
        
        public Task<IEnumerable<Basket>> GetBasketByCustomerAsync(string customerCode); // get asiakasnumeron perusteella
        
        // lisää
        public Task<Basket> AddBasketAsync(Basket basket);
    }
}
