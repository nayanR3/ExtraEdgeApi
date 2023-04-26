using ExtraEdgeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraEdgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MobileController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public MobileController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/mobiles
        [HttpGet]
        [Route("GetAllMobiles")]
        public async Task<ActionResult<IEnumerable<Mobile>>> GetMobiles()
        {
            if (_dbContext.mobiles == null)
                return NotFound();

            return await _dbContext.mobiles.ToListAsync();
        }

        // GET : api/mobiles/id
        [HttpGet]
        [Route("GetMobile/{id}")]

        public async Task<ActionResult<Mobile>> GetMobile(int id)
        {
            if (_dbContext.mobiles == null)
                return NotFound();

            var mobile = await _dbContext.mobiles.FindAsync(id);

            if (mobile == null)
                return NotFound();

            return mobile;
        }



        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult<Mobile>> PostMobile(Mobile mobile)
        {
            _dbContext.mobiles.Add(mobile);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMobile), new { id = mobile.MobileId }, mobile);
        }

        [HttpPut]
        [Route("Update/{id}")]

        public async Task<IActionResult> PutMobile(int id, Mobile mobile)
        {
            if (id != mobile.MobileId)
                return BadRequest();

            _dbContext.Entry(mobile).State = EntityState.Modified;


            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        private bool MobileExists(long id)
        {
            return (_dbContext.mobiles?.Any(e => e.MobileId == id)).GetValueOrDefault();
        }


        [HttpDelete]
        [Route("Delete/{id}")]

        public async Task<ActionResult> DeleteMobile(int id)
        {
            if (_dbContext == null)
                return NotFound();

            var mobile = await _dbContext.mobiles.FindAsync(id);
            if (mobile == null)
                return NotFound();

            _dbContext.mobiles.Remove(mobile);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}
