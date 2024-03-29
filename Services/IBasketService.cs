﻿using GastroAPI.Models;

namespace GastroAPI.Services
{
    public interface IBasketService
    {
        
        public Task<BasketDTO> GetBasketAsync(long id); // hae yksi id:n perusteella
     
        public Task<IEnumerable<BasketDTO>> GetBasketsAsync(); // hae kaikki

        
        public Task<IEnumerable<BasketDTO>> GetBasketsAsync(string tablenumber); // hae pöytänumeron perusteella
        

        // hae asiakasnumeron perusteella
        public Task<IEnumerable<BasketDTO>> GetBasketByCustomerAsync(string customerCode);
        

        // luo
        public Task<Basket> CreateBasketAsync(Basket dto);
    }
}
