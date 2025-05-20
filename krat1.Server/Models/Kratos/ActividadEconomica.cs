using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krat1.Server.Models.Kratos
{
    public class ActividadEconomica
    {
        public int actividad_id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string codigo_ciiu { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string categoria { get; set; }
        public string impuesto_retencion { get; set; }
        public bool activo { get; set; }
        [DataType(DataType.DateTime)]
        public  datetime creado_en{ get; set; }
        [DataType(DataType.DateTime)]
        public  datetime actualizado_en{ get; set; }
    
    }
}
