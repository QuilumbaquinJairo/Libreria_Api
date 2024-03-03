using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Data
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo Nombre debe tener como máximo {50} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo Apellido debe tener como máximo {50} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Correo no tiene un formato válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "El campo Teléfono debe tener 10 dígitos y comenzar con '09'")]
        public string Telefono { get; set; }
        public bool Sancion { get; set; }
        public string Facultad { get; set; }
    }
}
