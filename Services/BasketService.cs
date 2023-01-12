using GastroAPI.Models;
using GastroAPI.Repositories;

namespace GastroAPI.Services
{
    public class BasketService : IBasketService
    {
        // service = toimintalogiikka

        // tarvitaan viittaus repositoryyn:
        public readonly IBasketRepository _repository;

        // constructor
        public BasketService(IBasketRepository repository)
        {
            _repository = repository;
        }

        /*
        public async Task<BasketDTO> GetBasketAsync(long id)
        {
            Basket basket = await _repository.GetBasketAsync(id); 

            if (basket != null) 
            {

                return BasketToDTO(basket); // jos löytyy niin tehdään siitä DTO
            }
            return null; 
        }
        */

        public async Task<IEnumerable<BasketDTO>> GetBasketsAsync()
        {
            IEnumerable<Basket> baskets = await _repository.GetBasketsAsync(); 
            List<BasketDTO> result = new List<BasketDTO>(); 
            foreach (Basket i in baskets) 
            {
                result.Add(BasketToDTO(i)); 
            }
            return result; 
        }

        // taa on sen poytanumeron perusteella hakua varten
        public async Task<IEnumerable<BasketDTO>> GetBasketsAsync(long id)
        {
            IEnumerable<Basket> baskets = await _repository.GetBasketsAsync();
            List<BasketDTO> result = new List<BasketDTO>();
            foreach (Basket i in baskets)
            {
                result.Add(BasketToDTO(i));
            }
            return result;
        }

        private BasketDTO BasketToDTO(Basket basket)
        {
            BasketDTO dto = new BasketDTO();

            // vähä sekava viel
            if (basket.Item != null)
            {
                dto.Item = basket.Item.Name;
            }

            if (basket.Price != null)
            {
                dto.Price = basket.Price.Price;
            }

            dto.Amount = basket.Amount;

            return dto;
        }
    }
}
