using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;

namespace krat1.Server.Models.Kratos
{
    public class Permisos
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        [ForeignKey("Roles")]
        public int rolesId { get; set; }
        public Roles? permisosrolesId { get; set; }
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public string descripcion { get; set; }
        public string codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public string moduloId { get; set; }
        public bool consultar { get; set; }
        public bool leer { get; set; }
        public bool insertar { get; set; }
        public bool editar { get; set; }
        public bool eliminar { get; set; }
        public bool importar { get; set; }
        public bool exportar { get; set; }
    }
}
