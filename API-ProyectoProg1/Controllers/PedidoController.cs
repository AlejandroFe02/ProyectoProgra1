using API_ProyectoProg1.Data;
using API_ProyectoProg1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoProg1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public PedidoController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Pedido> pedidos = await _db.Pedido.ToListAsync();
            return Ok(pedidos);
        }

        // GET api/<PedidoController>/5
        [HttpGet("{PedidoId}")]
        public async Task<IActionResult> Get(string PedidoId)
        {
            Pedido pedido = await _db.Pedido.FirstOrDefaultAsync(p => p.PedidoId == PedidoId);
            if (pedido == null)
            {
                return BadRequest("El pedido no existe");
            }
            return Ok(pedido);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            Pedido pedido2 = await _db.Pedido.FirstOrDefaultAsync(x => x.PedidoId == pedido.PedidoId);
            if (pedido2 == null && pedido != null)
            {
                Ropa verificar = await _db.Ropa.FirstOrDefaultAsync(x => x.Codigo == pedido.PedidoId);
                if (verificar == null)
                {
                    return BadRequest("No existe ese distribuidor");
                }
                else
                {
                    Distribuidor vendedor = await _db.Distribuidor.FirstOrDefaultAsync(x => x.IdDistribuidor == pedido.IdDistribuidor);
                    if (vendedor == null)
                    {
                        return BadRequest("No existe ese distribuidor");
                    }
                    else
                    {

                        if (pedido.Stock < 0)
                        {
                            return BadRequest("Cantidad en Stock invalido");
                        }
                        else
                        {
                            if (pedido.PrecioDocena > 0)
                            {
                                pedido.PrecioVentaUnid = pedido.PrecioDocena / 12;
                            }
                            else
                            {
                                return BadRequest("Precio por docena invalido");
                            }
                            await _db.Pedido.AddAsync(pedido);
                            await _db.SaveChangesAsync();
                            return Ok(pedido);
                        }
                    }
                        
                }
                
            }
            return BadRequest("La solicitud es inválida");
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{PedidoId}")]
        public async Task<IActionResult> Put(string PedidoId, [FromBody] Pedido pedido)
        {
            Pedido pedido2 = await _db.Pedido.FirstOrDefaultAsync(p => p.PedidoId == pedido.PedidoId);

            if (pedido2 != null)
            {
                if (pedido.PrecioDocena > 0)
                {
                    pedido.PrecioVentaUnid = pedido.PrecioDocena / 12;
                }
                else
                {
                    return BadRequest("Precio por docena no valido");
                }

                pedido2.PedidoId = pedido.PedidoId != null ? pedido.PedidoId : pedido2.PedidoId;
                pedido2.Nombre = pedido.Nombre != null ? pedido.Nombre : pedido2.Nombre;
                pedido2.IdDistribuidor = pedido.IdDistribuidor != null ? pedido.IdDistribuidor : pedido2.IdDistribuidor;
                pedido2.Marca = pedido.Marca != null ? pedido.Marca : pedido2.Marca;
                pedido2.Tipo = pedido.Tipo != null ? pedido.Tipo : pedido2.Tipo;
                pedido2.Stock = pedido.Stock != null ? pedido.Stock : pedido2.Stock;
                pedido2.PrecioDocena = pedido.PrecioDocena != null ? pedido.PrecioDocena : pedido2.PrecioDocena;
                pedido2.PrecioVentaUnid = pedido.PrecioVentaUnid != null ? pedido.PrecioVentaUnid : pedido2.PrecioVentaUnid;
                _db.Pedido.Update(pedido2);
                await _db.SaveChangesAsync();
                return Ok(pedido);
            }
            return BadRequest("El objeto no existe");
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{PedidoId}")]
        public async Task<IActionResult> Delete(string PedidoId)
        {
            Pedido pedido = await _db.Pedido.FirstOrDefaultAsync(p => p.PedidoId == PedidoId);

            if (pedido != null)
            {
                _db.Pedido.Remove(pedido);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No existe el pedido");
        }
    }
}
