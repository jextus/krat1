using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;

namespace krat1.Server.Models.Kratos
{
    public class Empresas
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        [ForeignKey("TipoSociedad")]
        public int tiposociedadId { get; set; }
        public TiposSociedades? empresaSociedad_fk { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [ForeignKey("ActividadEconomica")]
        public int actividadId { get; set; }
        public ActividadEconomica? empresaActividad_fk { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [ForeignKey("RegimenTributario")]
        public int regimenId { get; set; }
        public RegimenesTributarios? empresaRegimen_fk { get; set; }
        public int token { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string razonSocial { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string nombreComercial { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nit { get; set; }
        public string dv { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string representanteLegal { get; set; }
        public bool activo { get; set; }
        [DataType(DataType.Date)]
        public DateTime creado_en { get; set; }
        [DataType(DataType.Date)]
        public DateTime actualizado_en { get; set; }


    }


}
