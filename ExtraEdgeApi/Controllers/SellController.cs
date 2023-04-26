using ExtraEdgeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraEdgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SellController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public SellController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/sells
        [HttpGet]
        [Route("GetAllSell")]
        public async Task<ActionResult<IEnumerable<Sell>>> GetSell()
        {
            if (_dbContext.sells == null)
                return NotFound();

            return await _dbContext.sells.ToListAsync();
        }

        // GET : api/sells/id
        [HttpGet]
        [Route("GetSell/{id}")]

        public async Task<ActionResult<Sell>> GetSell(int id)
        {
            if (_dbContext.sells == null)
                return NotFound();

            var sell = await _dbContext.sells.FindAsync(id);

            if (sell == null)
                return NotFound();

            return sell;
        }



        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult<Sell>> PostSell(Sell sell)
        {
            _dbContext.sells.Add(sell);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSell), new { id = sell.SellId }, sell);
        }

        [HttpPut]
        [Route("Update/{id}")]

        public async Task<IActionResult> PutSell(int id, Sell sell)
        {
            if (id != sell.SellId)
                return BadRequest();

            _dbContext.Entry(sell).State = EntityState.Modified;


            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        private bool SellExists(long id)
        {
            return (_dbContext.sells?.Any(e => e.SellId == id)).GetValueOrDefault();
        }


        [HttpDelete]
        [Route("Delete/{id}")]

        public async Task<ActionResult> DeleteSell(int id)
        {
            if (_dbContext == null)
                return NotFound();

            var sell = await _dbContext.sells.FindAsync(id);
            if (sell == null)
                return NotFound();

            _dbContext.sells.Remove(sell);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}
