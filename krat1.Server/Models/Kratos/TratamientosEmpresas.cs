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
        public string tipoImpuesto { get; set; }
        public Impuestos? impuestos_fk { get; set; }

       
        public string porcentaje { get; set; }
    }
}
