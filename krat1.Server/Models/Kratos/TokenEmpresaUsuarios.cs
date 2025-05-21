using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Identity;

namespace krat1.Server.Models.Kratos
{
    public class TokenEmpresaUsuarios
    {
        public int id { get; set; }
        [ForeignKey("Empresas")]
        public int token { get; set; }
        public Empresas? tokenEmpresa_fk { get; set; }
        [DataType(DataType.Password)]
        public string contraseña { get; set; }
        [ForeignKey("TokenEmpresaUsuario")]
        public string tokenUsuario { get; set; }
        public TokenEmpresaUsuarios? tokenUsuarios_fk { get; set; }



    }
}
