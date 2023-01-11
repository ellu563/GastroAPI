using GastroAPI.Models;

namespace GastroAPI.Repositories
{
    public interface IItemRepository
    {
        public Task<Item> GetItemAsync(long id); // get yhdelle id:n perusteella
        public Task<IEnumerable<Item>> GetItemsAsync(); // get koko listalle
        public Task<IEnumerable<Item>> QueryItems(String query); // get hakusanan perusteella
    }
}
