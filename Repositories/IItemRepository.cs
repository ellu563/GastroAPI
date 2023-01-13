using GastroAPI.Models;

namespace GastroAPI.Repositories
{
    public interface IItemRepository
    {
        public Task<Item> GetItemAsync(long id); // get yhdelle id:n perusteella
        public Task<IEnumerable<Item>> GetItemsAsync(); // get koko listalle
        public Task<IEnumerable<Item>> QueryItems(String query); // get hakusanan perusteella


        // halutaan saada pelkästään yksi
        public Task<Item> QueryItem(String query); // get hakusanan perusteella

        // haetaan nimen perusteella
        public Task<Item> GetItemByNameAsync(string name);

        public Task<Item> GetItemByPriceAsync(string price);

    }
}
