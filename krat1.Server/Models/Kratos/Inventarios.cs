using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace krat1.Server.Models.Kratos
{
    public class Inventarios
    {
        public int id { get; set; }
       
        
        [ForeignKey("Productos")]
        public int productoId { get; set; }
        public Productos? producto_fk { get; set; }
        
        
        [ForeignKey("PuntoVentas")]
        public int puntoVentaId { get; set; }
        public PuntoVentas? puntoVenta_fk { get; set; }
        
        
        public int cantidad { get; set; }
        
        
        [DataType(DataType.DateTime)]
        public DateTime creado_en { get; set; }
        
        
        [DataType(DataType.DateTime)]
        public DateTime actualizado_en { get; set; }

    }
}
