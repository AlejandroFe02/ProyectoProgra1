using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ProyectoProg1.Models;
using API_ProyectoProg1.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoProg1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidorController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public DistribuidorController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<DistribuidorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Distribuidor> products = await _db.Distribuidor.ToListAsync();
            return Ok(products);
        }

        // GET api/<DistribuidorController>/5
        [HttpGet("{IdDistribuidor}")]
        public async Task<IActionResult> Get(int IdDistribuidor)
        {
            Distribuidor vendedor = await _db.Distribuidor.FirstOrDefaultAsync(x => x.IdDistribuidor == IdDistribuidor);
            if (vendedor == null)
            {
                return BadRequest();
            }
            return Ok(vendedor);
        }

        // POST api/<DistribuidorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Distribuidor vendedor)
        {
            Distribuidor vendedor2 = await _db.Distribuidor.FirstOrDefaultAsync(x => x.IdDistribuidor == vendedor.IdDistribuidor);

            if (vendedor2 == null && vendedor != null)
            {
                await _db.Distribuidor.AddAsync(vendedor);
                await _db.SaveChangesAsync();
                return Ok(vendedor);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<DistribuidorController>/5
        [HttpPut("{IdDistribuidor}")]
        public async Task<IActionResult> Put(int IdDistribuidor, [FromBody] Distribuidor vendedor)
        {
            Distribuidor vendedor2 = await _db.Distribuidor.FirstOrDefaultAsync(x => x.IdDistribuidor == vendedor.IdDistribuidor);

            if (vendedor2 != null)
            {
                vendedor2.IdDistribuidor = vendedor.IdDistribuidor !=null ? vendedor.IdDistribuidor : vendedor2.IdDistribuidor;
                vendedor2.Nombre = vendedor.Nombre != null ? vendedor.Nombre : vendedor2.Nombre;
                vendedor2.Marca = vendedor.Marca != null ? vendedor.Marca : vendedor2.Marca;
                vendedor2.Contacto = vendedor.Contacto != null ? vendedor.Contacto : vendedor2.Contacto;
                vendedor2.NumeroCompra = vendedor.NumeroCompra != null ? vendedor.NumeroCompra : vendedor2.NumeroCompra;

                _db.Distribuidor.Update(vendedor2);
                await _db.SaveChangesAsync();
                return Ok(vendedor);
            }
            return BadRequest("El objeto ya existe");
        }


        // DELETE api/<DistribuidorController>/5
        [HttpDelete("{IdDistribuidor}")]
        public async Task<IActionResult> Delete(int IdDistribuidor)
        {
            Distribuidor vendedor = await _db.Distribuidor.FirstOrDefaultAsync(x => x.IdDistribuidor == IdDistribuidor);
            if (vendedor != null)
            {
                _db.Distribuidor.Remove(vendedor);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No existe el producto");
        }
    }
}
