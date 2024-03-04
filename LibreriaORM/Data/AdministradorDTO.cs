using System.ComponentModel.DataAnnotations;

namespace LibreriaORM.Modelo
{
    public class AdministradorDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        public string Telefono { get; set; }

        public bool Sancion { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Los privilegios son requeridos")]
        [AllowedValues(new string[] { "read", "create", "update", "delete" }, ErrorMessage = "Los privilegios deben ser 'read', 'create', 'update' o 'delete'.")]
        public string Privilegios { get; set; }
    }

    public class AllowedValuesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedValues;

        public AllowedValuesAttribute(string[] allowedValues)
        {
            _allowedValues = allowedValues;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            return _allowedValues.Contains(value.ToString().ToLower());
        }
    }
}
