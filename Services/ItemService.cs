using GastroAPI.Models;
using GastroAPI.Repositories;

namespace GastroAPI.Services
{
    public class ItemService : IItemService
    {
        // service = toimintalogiikka

        // tarvitaan viittaus repositoryyn:
        public readonly IItemRepository _repository;
      
        // constructor
        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        // haetaan itemia id:n perusteella
        public async Task<ItemDTO> GetItemAsync(long id)
        {
            Item item = await _repository.GetItemAsync(id); // ..service kutsuu repositorya

            if (item != null) // tarkistetaan löytyykö sieltä mitään
            {

                return ItemToDTO(item); // jos löytyy niin tehdään siitä DTO
            }
            return null; // jos ei ole löydetty, palautetaan null
        }

        // haetaan kaikki itemit
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            IEnumerable<Item> items = await _repository.GetItemsAsync(); // itemit tietokannasta
            List<ItemDTO> result = new List<ItemDTO>(); // lista dto:sta
            foreach (Item i in items) // käydään tietokannasta saatu items-lista läpi
            {
                result.Add(ItemToDTO(i)); // käydään jokainen item läpi, heitetään se ItemToDTO funktiolle, ja lopputulos lisätään listaan
            }
            return result; // palautetaan
        }

        // haetaan kyselyn perusteella, esim "juustohampurilainen"
        public async Task<IEnumerable<ItemDTO>> QueryItemsAsync(String query)
        {
            IEnumerable<Item> items = await _repository.QueryItems(query);
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            foreach (Item i in items)
            {
                itemDTOs.Add(ItemToDTO(i));
            }
            return itemDTOs;
        }

        // haetaan kyselyn perusteella
        public async Task<ItemDTO> QueryItemAsync(String query)
        {
            Item item = await _repository.QueryItem(query);

            if (item != null) // tarkistetaan löytyykö sieltä mitään
            {

                return ItemToDTO(item); // jos löytyy niin tehdään siitä DTO
            }
            return null; // jos ei ole löydetty, palautetaan null

        }

        // itemDTO
        private ItemDTO ItemToDTO(Item item)
        {
            ItemDTO dto = new ItemDTO();

            dto.Name = item.Name;
            dto.Price = item.Price;
            dto.Alv = item.Alv;
            dto.Calories = item.Calories;
            dto.Description = item.Description;
            dto.Image = item.Image;

            return dto;
        }
    }
}