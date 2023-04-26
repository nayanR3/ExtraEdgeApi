using ExtraEdgeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraEdgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public BrandController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/brands
        [HttpGet]
        [Route("GetAllBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if (_dbContext.brands == null)
                return NotFound();

            return await _dbContext.brands.ToListAsync();
        }

        // GET : api/brands/id
        [HttpGet]
        [Route("GetBrand/{id}")]

        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            if (_dbContext.brands == null)
                return NotFound();

            var brand = await _dbContext.brands.FindAsync(id);

            if (brand == null)
                return NotFound();

            return brand;
        }



        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _dbContext.brands.Add(brand);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrand), new { id = brand.BrandId }, brand);
        }

        [HttpPut]
        [Route("Update/{id}")]

        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.BrandId)
                return BadRequest();

            _dbContext.Entry(brand).State = EntityState.Modified;


            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        private bool BrandExists(long id)
        {
            return (_dbContext.brands?.Any(e => e.BrandId == id)).GetValueOrDefault();
        }


        [HttpDelete]
        [Route("Delete/{id}")]

        public async Task<ActionResult> DeleteBrand(int id)
        {
            if (_dbContext == null)
                return NotFound();

            var brand = await _dbContext.brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            _dbContext.brands.Remove(brand);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}
