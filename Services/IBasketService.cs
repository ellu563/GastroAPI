using GastroAPI.Models;

namespace GastroAPI.Services
{
    public interface IBasketService
    {
        /*
        public Task<BasketDTO> GetBasketAsync(long id); // hae yksi id:n perusteella
        */
        public Task<IEnumerable<BasketDTO>> GetBasketsAsync(); // hae kaikki

        public Task<IEnumerable<BasketDTO>> GetBasketsAsync(long id); // hae kaikki
    }
}
