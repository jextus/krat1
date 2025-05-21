using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace krat1.Server.Models.Kratos
{
    public class Productos
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public int codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        [ForeignKey("TratamientosEmpresas")]
        public int Impuesto { get; set; }
        public TratamientosEmpresas? tratamiento_fk { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]


        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string descripcion { get; set; }
        [ForeignKey("Categorias")]
        public string categoria { get; set; }
        public Categorias? categoria_fk { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string precio { get; set; }
        public string costo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string stockMinimo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public bool activo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime creado_en { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime actualizado_en { get; set; }
    }
}
