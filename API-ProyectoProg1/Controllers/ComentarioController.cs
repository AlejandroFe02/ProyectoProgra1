using API_ProyectoProg1.Data;
using API_ProyectoProg1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoProg1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public ComentarioController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Comentario> comentario = await _db.Comentario.ToListAsync();
            return Ok(comentario);
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{IdComentario}")]
        public async Task<IActionResult> Get(int IdComentario)
        {
            Comentario comentario = await _db.Comentario.FirstOrDefaultAsync(x => x.IdComentario == IdComentario);
            if (comentario == null)
            {
                return BadRequest();
            }
            return Ok(comentario);
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            Comentario comentario2 = await _db.Comentario.FirstOrDefaultAsync(x => x.IdComentario == comentario.IdComentario);

            if (comentario2 == null && comentario != null)
            {
                await _db.Comentario.AddAsync(comentario);
                await _db.SaveChangesAsync();
                return Ok(comentario);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{IdComentario}")]
        public async Task<IActionResult> Put(int IdComentario, [FromBody] Comentario comentario)
        {
            Comentario comentario2 = await _db.Comentario.FirstOrDefaultAsync(x => x.IdComentario == comentario.IdComentario);

            if (comentario2 != null)
            {
                comentario2.IdComentario = comentario.IdComentario != null ? comentario.IdComentario : comentario2.IdComentario;
                comentario2.CedulaAutor = comentario.CedulaAutor != null ? comentario.CedulaAutor : comentario2.CedulaAutor;
                comentario2.NombreAutor = comentario.NombreAutor != null ? comentario.NombreAutor : comentario2.NombreAutor;
                comentario2.Mensaje = comentario.Mensaje != null ? comentario.Mensaje : comentario2.Mensaje;
                comentario2.Fecha = comentario.Fecha != null ? comentario.Fecha : comentario.Fecha;

                _db.Comentario.Update(comentario2);
                await _db.SaveChangesAsync();
                return Ok(comentario);
            }
            return BadRequest("El objeto ya existe");
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{IdComentario}")]
        public async Task<IActionResult> Delete(int IdComentario)
        {
            Comentario comentario = await _db.Comentario.FirstOrDefaultAsync(x => x.IdComentario == IdComentario);
            if (comentario != null)
            {
                _db.Comentario.Remove(comentario);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No existe el Comentario");
        }
    }
}
