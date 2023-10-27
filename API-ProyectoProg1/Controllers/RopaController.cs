using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ProyectoProg1.Models;
using API_ProyectoProg1.Data;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoProg1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RopaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public RopaController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<RopaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Ropa> products = await _db.Ropa.ToListAsync();
            
            return Ok(products);
        }

        // GET api/<RopaController>/5
        [HttpGet("{Codigo}")]
        public async Task<IActionResult> Get(string Codigo)
        {
            Ropa producto = await _db.Ropa.FirstOrDefaultAsync(x => x.Codigo == Codigo);
            if (producto == null)
            {
                return BadRequest();
            }
            return Ok(producto);
        }

        // POST api/<RopaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ropa producto)
        {
            Ropa producto2 = await _db.Ropa.FirstOrDefaultAsync(x => x.Codigo == producto.Codigo);

            if (producto2 == null && producto != null)
            {
                if (producto.Stock < 0)
                {
                    return BadRequest("Cantidad en Stock invalido");
                }
                else
                {
                    if (producto.PrecioDocena > 0)
                    {
                        producto.PrecioVentaUnid = producto.PrecioDocena / 12;
                    }
                    else
                    {
                        return BadRequest("Precio por docena invalido");
                    }
                    await _db.Ropa.AddAsync(producto);
                    await _db.SaveChangesAsync();
                    return Ok(producto);

                }
            }

            return BadRequest("El objeto ya existe");
        }

        // PUT api/<RopaController>/5
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> Put(string Codigo, [FromBody] Ropa producto)
        {
            Ropa producto2 = await _db.Ropa.FirstOrDefaultAsync(x => x.Codigo == producto.Codigo);

            if (producto2 != null)
            {
                if (producto.PrecioDocena > 0)
                {
                    producto.PrecioVentaUnid = producto.PrecioDocena / 12;
                }
                else
                {
                    return BadRequest("Precio por docena no valido");
                }

                producto2.Codigo = producto.Codigo != null ? producto.Codigo : producto2.Codigo;
                producto2.Nombre = producto.Nombre != null ? producto.Nombre : producto2.Nombre;
                producto2.IdDistribuidor = producto.IdDistribuidor != null ? producto.IdDistribuidor : producto2.IdDistribuidor;
                producto2.Marca = producto.Marca != null ? producto.Marca : producto2.Marca;
                producto2.Tipo = producto.Tipo != null ? producto.Tipo : producto2.Tipo;
                producto2.Stock = producto.Stock != null ? producto.Stock : producto2.Stock;
                producto2.PrecioDocena = producto.PrecioDocena != null ? producto.PrecioDocena : producto2.PrecioDocena;
                producto2.PrecioVentaUnid = producto.PrecioVentaUnid != null ? producto.PrecioVentaUnid : producto2.PrecioVentaUnid;

                _db.Ropa.Update(producto2);
                await _db.SaveChangesAsync();
                return Ok(producto);
            }
            return BadRequest("El objeto ya existe");
        }


        // DELETE api/<RopaController>/5
        [HttpDelete("{Codigo}")]
        public async Task<IActionResult> Delete(string Codigo)
        {
            Ropa producto = await _db.Ropa.FirstOrDefaultAsync(x => x.Codigo == Codigo);
            if (producto != null)
            {
                _db.Ropa.Remove(producto);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No existe el producto");
        }
    }
}