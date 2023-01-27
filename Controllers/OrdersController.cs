using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastroAPI.Models;
using GastroAPI.Services;

namespace GastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly GastroBarContext _context;

        private readonly IOrderService _service;

        public OrdersController(IOrderService service, GastroBarContext context)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Orders
        /// <summary>
        /// Haetaan kaikki tilaukset
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        /// <summary>
        /// Haetaan id:n perusteella
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // GET pöytänumeron perusteella, ORDERDTO
        // include (tilauksessa olevat products) + haetaan vain ne tilaukset jossa status = "open"
        /// <summary>
        /// Haetaan pöytänumeron perusteella
        /// </summary>
        /// <param name="tablenumber"></param>
        /// <returns></returns>
        [HttpGet("table/{tablenumber}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders(string tablenumber)
        {
            return Ok(await _service.GetOrdersAsync(tablenumber)); // Ok=http 200
        }

        // GET status OPEN
        /// <summary>
        /// Haetaan pöytänumeron perusteella, jossa status open
        /// </summary>
        /// <param name="tablenumber"></param>
        /// <returns></returns>
        [HttpGet("table/tables/{tablenumber}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersBy(string tablenumber)
        {
            return Ok(await _service.GetOrdersByAsync(tablenumber)); // Ok=http 200
        }

        // GET status BILLING
        /// <summary>
        /// Haetaan pöytänumeron perusteella, jossa status billing
        /// </summary>
        /// <param name="tablenumber"></param>
        /// <returns></returns>
        [HttpGet("table/billing/{tablenumber}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersBillingBy(string tablenumber)
        {
            return Ok(await _service.GetOrdersBillingByAsync(tablenumber)); // Ok=http 200
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Muokkaa id:n perusteella
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Luo uuden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        /// <summary>
        /// Poista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
