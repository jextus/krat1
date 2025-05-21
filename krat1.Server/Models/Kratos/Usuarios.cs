using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Krat1.Server.Models.Kratos;
using Microsoft.AspNetCore.Identity;


namespace krat1.Server.Models.Kratos
{
    public class Usuarios
    {
        public int id { get; set; }


        [ForeignKey("Roles")]
        public int rolesId { get; set; }
        public Roles? usuariosrolesId { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string contraseña { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string confirmarContraseña { get; set; }



        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string email { get; set; }


        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nombres { get; set; }



        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string apellidos { get; set; }
      
        
        
        [DataType(DataType.PhoneNumber)]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string telefono { get; set; }
        
        
        public bool estado { get; set; }
        
        
        
        [DataType(DataType.DateTime)]
        public DateTime creado_en { get; set; }
        
        
        
        [DataType(DataType.DateTime)]
        public DateTime actualizado_en { get; set; }
    }
}
