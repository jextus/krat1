using krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;

namespace krat1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly KratosContext _context;
        public UsuariosController(KratosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<Usuarios>> Listar()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<Usuarios?> Consultar(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.id == id);
            return usuario;
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar(Usuarios usuario)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.id == usuario.id);
            if (usuarioExistente == null)
            {
                return BadRequest();
            }
            usuarioExistente.rolesId = usuario.rolesId;
            usuarioExistente.estado = usuario.estado;
            usuarioExistente.actualizadoEn = DateTime.Now;
            _context.Usuarios.Update(usuarioExistente);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return BadRequest();
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
