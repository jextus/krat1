using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace krat1.Server.Models.Kratos
{
    public class RegimenTributario
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }
        public bool estado { get; set; }
    }
}
