using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;

namespace krat1.Server.Models.Kratos
{
    public class Empresas
    {
        public int id { get; set; }
        [ForeignKey("TipoSociedad")]
        public int tiposociedadId { get; set; }
        public TipoSociedad? empresaSociedad_fk { get; set; }
        [ForeignKey("ActividadEconomica")]
        public int actividadId { get; set; }
        public ActividadEconomica? empresaActividad_fk { get; set; }
        [ForeignKey("RegimenTributario")]
        public int regimenId { get; set; }
        public RegimenTributario? empresaRegimen_fk { get; set; }
        public int token { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public string nit { get; set; }
        public string dv { get; set; }
        public string telefono { get; set; }
        
  

            
    }

    }
}
