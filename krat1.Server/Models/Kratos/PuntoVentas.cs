using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace krat1.Server.Models.Kratos
{
    public class PuntoVentas
    {
        public int id { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string nombre { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? direccion { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? telefono { get; set; }
        
        
        [ForeignKey("Usuario")]
        public int ResponsableId { get; set; }
        public Usuarios? usuario_fk { get; set; }
        
        
        public bool activo { get; set; }
        
        
        [DataType(DataType.DateTime)]
        public DateTime creado_en { get; set; }
        
        
        [DataType(DataType.DateTime)]
        public DateTime actualizado_en { get; set; }
    }
}
