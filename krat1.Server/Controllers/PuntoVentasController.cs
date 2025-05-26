using krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;

namespace krat1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoVentasController : ControllerBase
    {
        private readonly KratosContext _context;
        public PuntoVentasController(KratosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<PuntoVentas>> Listar()
        {
            var puntos = await _context.PuntoVentas.ToListAsync();
            return puntos;
        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<PuntoVentas?> Consultar(int id)
        {
            var punto = await _context.PuntoVentas.FirstOrDefaultAsync(p => p.id == id);
            return punto;
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar(PuntoVentas punto)
        {
            var puntoExistente = await _context.PuntoVentas.FirstOrDefaultAsync(p => p.id == punto.id);
            if (puntoExistente == null)
            {
                return BadRequest();
            }
            puntoExistente.responsableId = punto.responsableId;
            puntoExistente.activo = punto.activo;
            puntoExistente.actualizadoEn = DateTime.Now;
            _context.PuntoVentas.Update(puntoExistente);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var punto = await _context.PuntoVentas.FindAsync(id);
            if (punto == null)
            {
                return BadRequest();
            }
            _context.PuntoVentas.Remove(punto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
