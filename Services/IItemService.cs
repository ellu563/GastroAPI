using GastroAPI.Models;

namespace GastroAPI.Services
{
    public interface IItemService
    {
        public Task<ItemDTO> GetItemAsync(long id);
        public Task<IEnumerable<ItemDTO>> GetItemsAsync();
        public Task<IEnumerable<ItemDTO>> QueryItemsAsync(String query);

        public Task<ItemDTO> QueryItemAsync(String query);

    }
}
