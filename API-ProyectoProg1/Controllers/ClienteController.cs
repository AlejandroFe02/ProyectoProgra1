using API_ProyectoProg1.Data;
using API_ProyectoProg1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoProg1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public ClienteController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Cliente> cliente = await _db.Cliente.ToListAsync();
            return Ok(cliente);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{Cedula}")]
        public async Task<IActionResult> Get(string Cedula)
        {
            Cliente cliente = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == Cedula);
            if (cliente == null)
            {
                return BadRequest();
            }
            return Ok(cliente);
        }

        // POST api/<ClientesController>
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            Cliente cliente2 = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == cliente.Cedula);

            if (cliente2 == null && cliente != null)
            {
                await _db.Cliente.AddAsync(cliente);
                await _db.SaveChangesAsync();
                return Ok(cliente);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{Cedula}")]
        public async Task<IActionResult> Put(int Cedula, [FromBody] Cliente cliente)
        {
            Cliente cliente2 = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == cliente.Cedula);

            if (cliente2 != null)
            {
                cliente2.Cedula = cliente.Cedula != null ? cliente.Cedula : cliente2.Cedula;
                cliente2.Nombre = cliente.Nombre != null ? cliente.Nombre : cliente2.Nombre;
                cliente2.Apellido = cliente.Apellido != null ? cliente.Apellido : cliente2.Apellido;
                cliente2.Correo = cliente.Correo != null ? cliente.Correo : cliente2.Correo;
                cliente2.Direccion = cliente.Direccion != null ? cliente.Direccion : cliente2.Direccion;
                cliente2.Telefono = cliente.Telefono != null ? cliente.Telefono : cliente2.Telefono;
                cliente2.Contrasenia = cliente.Contrasenia != null ? cliente.Contrasenia : cliente2.Contrasenia;

                _db.Cliente.Update(cliente2);
                await _db.SaveChangesAsync();
                return Ok(cliente);
            }
            return BadRequest("El objeto ya existe");
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{Cedula}")]
        public async Task<IActionResult> Delete(string Cedula)
        {
            Cliente cliente = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == Cedula);
            if (cliente != null)
            {
                _db.Cliente.Remove(cliente);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No existe el producto");
        }
    }
}
