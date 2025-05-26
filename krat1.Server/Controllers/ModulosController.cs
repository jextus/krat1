using krat1.Server.Models.Kratos;
using Krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;

namespace krat1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulosController : ControllerBase
    {
        private readonly KratosContext _context;
        public ModulosController(KratosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<Modulos>> Listar()
        {
            var modulos = await _context.Modulos.ToListAsync();
            return modulos;
        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<Modulos?> Consultar(int id)
        {
            var modulo = await _context.Modulos.FirstOrDefaultAsync(m => m.id == id);
            return modulo;
        }
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar(Modulos modulo)
        {
            var moduloExistente = await _context.Modulos.FirstOrDefaultAsync(m => m.id == modulo.id);
            if (moduloExistente == null)
            {
                return BadRequest();
            }
            moduloExistente.nombre = modulo.nombre;
            _context.Modulos.Update(moduloExistente);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return BadRequest();
            }
            _context.Modulos.Remove(modulo);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
