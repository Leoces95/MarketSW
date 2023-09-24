using Market.API.Data;
using Market.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesControllers : ControllerBase
    {
        // Atributo
        private readonly DataContext _context;
        // Constructor 
        public CountriesControllers(DataContext context)
        {
            _context = context;
        }
        // Controlador get
        // GET CON *
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        // Lista    con nombre del campo en específico y con el where
        // GET POR PARÁMETRO --ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync (c => c.Id == id);
            if (country == null)
            {
                return NotFound(); // 404 
            }
            else
            {
                return Ok("Countries [{country.Id}]");
            }


        }

        // INSERT
        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country); //200

        }
        // UPDATE

        [HttpPut]
        public async Task<ActionResult> Put(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country); //200
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.Countries
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            if (filaafectada == 0)
            {
                return NotFound(); // 404
            }
            return NoContent();
        }
    }
}