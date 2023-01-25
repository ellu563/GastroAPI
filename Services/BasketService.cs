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
            newBasket.Amount = dto.Amount;
            newBasket.Item = dto.Item;
            newBasket.Price = dto.Price;
            newBasket.Status = dto.Status;

            /* kehitysvaiheen testejä:
            Item item = await _itemRepository.QueryItem((Convert.ToString(dto.Item)));

            if (item != null)
            {
                newBasket.Item = item;
                newBasket.Price = item;
            }*/


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

        private BasketDTO BasketToDTO(Basket basket)
        {
            BasketDTO dto = new BasketDTO();

            /*
            // toiminta itemin kannasta hakua varten

            if (basket.Item != null)
            {
                dto.Item = basket.Item.Name;
            }

            if (basket.Price != null)
            {
                dto.Price = basket.Item.Price;
            }
            */

           dto.ProductId = basket.ProductId;
           dto.Item = basket.Item;
           dto.Price = basket.Price;
           dto.Amount = basket.Amount;
           dto.Status = basket.Status;

           return dto;
        }

         /*
         // kehitysvaiheen testejä:

         private async Task<Basket> DTOToSuperBasket(BasketSuperDTO dto)
         {
             Basket newBasket = new Basket();

             newBasket.Id = dto.Id;
             newBasket.TableNumber = dto.TableNumber;
             newBasket.Amount = dto.Amount;

             Item item = await _itemRepository.QueryItem(dto.Item);

             if (item != null)
             {
                 newBasket.Item= item;
                 newBasket.Price = item;
             }

             await _repository.AddBasketAsync(newBasket);
             return newBasket;
             // huom. jos taa menee piloille poista naa kaikki postin service ja repot ja palauta controllerista se vanha
         }
         private BasketSuperDTO BasketToSuperDTO(Basket basket)
         { 
             BasketSuperDTO dto = new BasketSuperDTO();

             dto.Id = basket.Id;
             dto.TableNumber = basket.TableNumber;

             if (basket.Item != null)
             {
                 dto.Item = basket.Item.Name;
             }

             if (basket.Price != null)
             {
                 dto.Price = basket.Price.Price;
             }

             dto.Amount = basket.Amount;
             dto.OrderTime = basket.OrderTime;

             return dto;
         }
         */
    }
}
