using GastroAPI.Models;
using GastroAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace GastroAPI.Services
{
    public class OrderService : IOrderService
    {
        // tarvitaan viittaus repositoryyn:
        public readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        
        // etsitään pöytänumeron perusteella
        // tää toimii kyl iha sillee et palauttaa ne order dto:ina
        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync(string tablenumber)
        {
            IEnumerable<Order> orders = await _repository.GetOrdersAsync(tablenumber);
            List<OrderDTO> result = new List<OrderDTO>();
            foreach (Order i in orders)
            {
                result.Add(OrderToDTO(i));
            }
            return result;
        }

        // GET pelkällä orderilla, ei order dto
        public async Task<IEnumerable<Order>> GetOrdersByAsync(string tablenumber)
        {
            IEnumerable<Order> orders = await _repository.GetOrdersByAsync(tablenumber);
            return orders;
        
        }

        // muunnetaan order orderDTOksi
        private OrderDTO OrderToDTO(Order order)
        {
            OrderDTO dto = new OrderDTO();

            dto.TableNumber = order.TableNumber;

            
            /*if (order.Orders != null)
            {
                order.Orders = new List<Products>();
                foreach (Products i in order.Orders)
                {
                    dto.Orders = order.Orders;
                }
            }*/
            dto.Orders = order.Orders;
            dto.Status = order.Status;

            return dto;
        }
     
        private ProductsDTO ProductsToDTO(Products products)
        {
            ProductsDTO dto = new ProductsDTO();
            dto.Item = products.Item;
            dto.Price = products.Price;
            dto.Amount = products.Amount;

            return dto;
        }
    }
}
