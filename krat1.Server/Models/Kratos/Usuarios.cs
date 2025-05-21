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
        [ForeignKey("TokenEmpresaUsuario")]
        public string tokenUsuario { get; set; }
        public TokenEmpresaUsuarios? tokenUsuario_fk { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string contraseña { get; set; }
       [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string email { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string apellidos { get; set; }
      
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }
        public bool estado { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime creado_en { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime actualizado_en { get; set; }
    }
}
