using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Identity;

namespace krat1.Server.Models.Kratos
{
    public class TratamientosEmpresas
    {
        public int id { get; set; }


        
        [ForeignKey("Empresas")]
        public int empresaId { get; set; }
        public Empresas? empresa_fk { get; set; }
        
        
        [ForeignKey("Impuestos")]
        public int tipoImpuesto { get; set; }
        public Impuestos? impuestos_fk { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string porcentaje { get; set; }
    }
}
