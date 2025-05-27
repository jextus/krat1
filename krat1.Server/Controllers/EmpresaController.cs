using krat1.Server.Models.Kratos;
using krat1.Server.Services.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;

namespace krat1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly KratosContext _context;
        private readonly IEncriptarService _encryptionService;

        public EmpresaController(KratosContext context, IEncriptarService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        [HttpPost]
        [Route("RegistroEmpresa")]
        public async Task<IActionResult> RegistroEmpresa(Empresas empresas)
        {
       
            empresas.contraseña = _encryptionService.Encriptar(empresas.contraseña);
            empresas.confirmarContraseña = _encryptionService.Encriptar(empresas.confirmarContraseña);

            await _context.Empresas.AddAsync(empresas);
            await _context.SaveChangesAsync();
            return Ok(empresas);
        }

        [HttpGet]
        [Route("ListarEmpresas")]
        public async Task<ActionResult<List<Empresas>>> ListarEmpresas()
        {
            var empresas = await _context.Empresas
                .Include(e => e.empresasociedadFk)
                .Include(e => e.empresaactividadFk)
                .Include(e => e.empresaregimenFk)
                .ToListAsync();

            empresas.ForEach(e => {
                e.contraseña = _encryptionService.Desencriptar(e.contraseña);
                e.confirmarContraseña = _encryptionService.Desencriptar(e.confirmarContraseña);
            });

            return empresas;
        }

        [HttpGet]
        [Route("ConsultarEmpresa")]
        public async Task<ActionResult<Empresas>> ConsultarEmpresa(int id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.empresasociedadFk)
                .Include(e => e.empresaactividadFk)
                .Include(e => e.empresaregimenFk)
                .FirstOrDefaultAsync(e => e.id == id);

            if (empresa == null)
                return NotFound();

            // Desencriptar las contraseñas
            empresa.contraseña = _encryptionService.Desencriptar(empresa.contraseña);
            empresa.confirmarContraseña = _encryptionService.Desencriptar(empresa.confirmarContraseña);

            return empresa;
        }

        [HttpPut]
        [Route("ActualizarEmpresa")]
        public async Task<IActionResult> ActualizarEmpresa(Empresas empresa)
        {
            var empresaExistente = await _context.Empresas.FirstOrDefaultAsync(e => e.id == empresa.id);
            if (empresaExistente == null)
            {
                return BadRequest("La empresa no existe.");
            }

            if (!string.IsNullOrEmpty(empresa.contraseña))
                empresaExistente.contraseña = _encryptionService.Encriptar(empresa.contraseña);

            if (!string.IsNullOrEmpty(empresa.confirmarContraseña))
                empresaExistente.confirmarContraseña = _encryptionService.Encriptar(empresa.confirmarContraseña);

  
            empresaExistente.tiposociedadId = empresa.tiposociedadId;
            empresaExistente.actividadId = empresa.actividadId;
            empresaExistente.regimenId = empresa.regimenId;
            empresaExistente.token = empresa.token;
            empresaExistente.nit = empresa.nit;
            empresaExistente.dv = empresa.dv;
            empresaExistente.telefono = empresa.telefono;
            empresaExistente.activo = empresa.activo;
            empresaExistente.creadoEn = empresa.creadoEn;
            empresaExistente.actualizadoEn = DateTime.Now;

            _context.Empresas.Update(empresaExistente);
            await _context.SaveChangesAsync();
            return Ok(empresaExistente);
        }

        [HttpDelete]
        [Route("EliminarEmpresa")]
        public async Task<IActionResult> EliminarEmpresa(int id)
        {
            var empresaEliminada = await _context.Empresas.FindAsync(id);
            if (empresaEliminada == null)
            {
                return BadRequest();
            }
            _context.Empresas.Remove(empresaEliminada);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}