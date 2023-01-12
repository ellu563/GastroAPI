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
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _service;
        private readonly GastroBarContext _context;

        public BasketsController(IBasketService service, GastroBarContext context)
        {
            _context = context;
            _service = service;
        }
        /// <summary>
        /// Hae kaikki basketit
        /// </summary>
        /// <returns></returns>
        // GET: api/Baskets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketDTO>>> GetBaskets()
        {
            return Ok(await _service.GetBasketsAsync()); // Ok=http 200
        }

        // yritetaan nyt hakea kaikkia sen poytanumeron perusteella
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<BasketDTO>>> GetBaskets(long id)
        {
            return Ok(await _service.GetBasketsAsync()); // Ok=http 200
        }

        /*
        // GET: api/Baskets/5
        /// <summary>
        /// Hae basket id:n perusteella
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BasketDTO>> GetBasket(long id) // palauttaa itemDTO:n, haetaan id:n perusteella
        {
            var item = await _service.GetBasketAsync(id); // kutsutaan serviceä.. joka kutsuu repositorya
            // await = async, eli säikeen voi vapauttaa muihin töihin

            if (item == null)
            {
                return NotFound(); // jos käyttäjä kysyy sellaista itemiä mitä ei ole, http 404 ei löytynyt mitään
            }

            return item;
        }
        */

        // PUT/POST/DELETE contekstin kautta

        // PUT: api/Baskets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasket(long id, Basket basket)
        {
            if (id != basket.Id)
            {
                return BadRequest();
            }

            _context.Entry(basket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketExists(id))
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

        // POST: api/Baskets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Basket>> PostBasket(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasket", new { id = basket.Id }, basket);
        }

        // DELETE: api/Baskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(long id)
        {
            var basket = await _context.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketExists(long id)
        {
            return _context.Baskets.Any(e => e.Id == id);
        }
    }
}
