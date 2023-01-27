using GastroAPI.Models;
using GastroAPI.Repositories;
using System.Drawing.Printing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GastroAPI.Services
{
    public class BasketService : IBasketService
    {
        // service = toimintalogiikka

        private readonly GastroBarContext _context;

        // tarvitaan viittaus repositoryyn:
        public readonly IBasketRepository _repository;

        // ja item repositoryyn
        public readonly IItemRepository _itemRepository;

        // constructor
        public BasketService(IBasketRepository repository, IItemRepository itemRepository, GastroBarContext context)
        {
            _repository = repository;
            _itemRepository = itemRepository;
            _context = context;
        }

        // luodaan uusi
        public async Task<Basket> CreateBasketAsync(Basket dto)
        {
            Basket newBasket = new Basket();

            newBasket.ProductId = dto.ProductId;
            newBasket.TableNumber = dto.TableNumber; 
            newBasket.CustomerCode = dto.CustomerCode;
            newBasket.Amount = dto.Amount;
            newBasket.Item = dto.Item;
            newBasket.Price = dto.Price;
            newBasket.Status = dto.Status;


            await _repository.AddBasketAsync(newBasket);
            return newBasket;
 
        }

        // haetaan yksi id:n perusteella
        public async Task<BasketDTO> GetBasketAsync(long id)
        {
            Basket basket = await _repository.GetBasketAsync(id); 

            if (basket != null) 
            {

                return BasketToDTO(basket); // jos löytyy niin tehdään siitä DTO
            }
            return null; 
        }
        
        // haetaan kaikki tilaukset
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

        
        // haetaan tuotteet kaikki poytanumeron perusteella
        public async Task<IEnumerable<BasketDTO>> GetBasketsAsync(string tablenumber)
        {
            IEnumerable<Basket> baskets = await _repository.GetBasketsAsync(tablenumber);
            List<BasketDTO> basketDTOs = new List<BasketDTO>();
            foreach (Basket i in baskets)
            {
                basketDTOs.Add(BasketToDTO(i));
            }
            return basketDTOs;
        }

        // haetaan tuotteet kaikki asiakasnumeron perusteella
        public async Task<IEnumerable<BasketDTO>> GetBasketByCustomerAsync(string customerCode)
        {
            IEnumerable<Basket> baskets = await _repository.GetBasketByCustomerAsync(customerCode);
            List<BasketDTO> basketDTOs = new List<BasketDTO>();
            foreach (Basket i in baskets)
            {
                basketDTOs.Add(BasketToDTO(i));
            }
            return basketDTOs;
        }

        private BasketDTO BasketToDTO(Basket basket)
        {
           BasketDTO dto = new BasketDTO();

           dto.ProductId = basket.ProductId;
           dto.Item = basket.Item;
           dto.Price = basket.Price;
           dto.Amount = basket.Amount;
           dto.Status = basket.Status;

           return dto;
        }

    }
}
