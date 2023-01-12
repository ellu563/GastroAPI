using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastroAPI.Models;
using GastroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // get kutsut haetaan servicen kautta
        private readonly IItemService _service;

        // käytetään post, put ja deletessä palvelua suoraan kontekstin kautta
        private readonly GastroBarContext _context;

        public ItemsController(IItemService service, GastroBarContext context) 
        {
            _service = service;
            _context = context;
        }

        /// <summary>
        /// Hakee kaikki tuotteet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {
            return Ok(await _service.GetItemsAsync()); // Ok=http 200
        }

        /// <summary>
        /// Hakee tuotteen id:n perusteella
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemDTO>> GetItem(long id) // palauttaa itemDTO:n, haetaan id:n perusteella
        {
            var item = await _service.GetItemAsync(id); // kutsutaan serviceä.. joka kutsuu repositorya
            // await = async, eli säikeen voi vapauttaa muihin töihin

            if (item == null)
            {
                return NotFound(); // jos käyttäjä kysyy sellaista itemiä mitä ei ole, http 404 ei löytynyt mitään
            }

            return item;
        }

        /// <summary>
        /// Hakee tuotteen hakusanan perusteella esim. juustohampurilainen
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("{query}")]
        public async Task<ActionResult<ItemDTO>> QueryItems(String query)
        {
            return Ok(await _service.QueryItemsAsync(query));
        }

        // PUT, POST JA DELETE 
        // käytetään palvelua contextin kautta, eikä ole tehty erikseen kolmikerrosrakennetta servicen ja repositoryn kautta
        // muokkaus ja poisto pitää tehdä id:n avulla
        // tässä vaiheessa ei tarvetta muokata niitä enempää

        // PUT: api/Items1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Muokkaa tuotteen tietoja id:n avulla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Luo uuden item/tuotteen
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items1/5
        /// <summary>
        /// Poistaa tuotteen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(long id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

    }
}
