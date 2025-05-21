using krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica.Server.Models;

namespace krat1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly KratosContext _context;
        public EmpresaController(KratosContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("RegistroEmpresa")]
        public async Task <IActionResult>  RegistroEmpresa (Empresas empresas)
        {
                 await _context.Empresas.AddAsync(empresas);
            await _context.SaveChangesAsync();
            return Ok(empresas);
        }
    }
}
