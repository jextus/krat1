using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;

namespace krat1.Server.Models.Kratos
{
    public class Impuestos
    {
        public int id { get; set; }



        [ForeignKey("ActividadEconomicas")]
        public int actividadId { get; set; }
        public ActividadEconomicas? impuestoActividad_fk { get; set; }


        [ForeignKey("RegimenesTributarios")]
        public int regimenId { get; set; }
        public RegimenesTributarios? impuestoRegimen_fk { get; set; }


        [ForeignKey("TiposSociedades")]
        public int sociedadesId { get; set; }
        public TiposSociedades? impuestoSociedades_fk { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string nombre { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string descripcion { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string codigo { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string porcentaje { get; set; }
    }
}
